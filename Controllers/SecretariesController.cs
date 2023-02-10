using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSis.Identity;
using WebSis.Models;
using WebSis.Services;

namespace WebSis.Controllers
{
    // Controller responsável pelas requisições de registro, listagem, exclusão e edição das secretarias.

    public class SecretariesController : Controller
    {
        private readonly ILogger<SecretariesController> _logger; // instância do objeto da interface ILogger que gerenciará os logs.

        public SecretariesController(ILogger<SecretariesController> logger)
        {
            // injeção de dependência do objeto de logs da biblioteca Serilog utilizando a interface ILogger.
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RegisterSecretaries(Secretaries newSecretary)
        {
            // O registro de secretarias é feito através de uma partial view que é renderizada em um modal dentro da view index de Home. A partial view mostra um formulário que abre junto ao modal e a requisição é feita por este método de Secretaries controller. O método recebe um objeto de secretarias como parâmetro e chama um método de SecretariesService que salva os dados inseridos e logo após trata o redirecionamento via ajax.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.

                SecretariesService ss = new SecretariesService(); // Instância da classe SecretariesService.
                ss.AddSecretary(newSecretary); // chamada do método presente em SecretariesService que salva os dados inseridos no banco de dados recebendo o objeto instanciado de secretarias.

                return Json(new { stats = "OK" });

            }
            catch (Exception e)
            {
                // Caso seja gerado uma excessão o usuário irá receber um alert informando que não foi possível realizar o cadastro e será redirecionado para a página de login precisando estabelcer uma conexão novamente.
                _logger.LogError("Erro ao Cadastrar Secretaria!" + e.Message);
                return Json(new { stats = "ERROR", message = "Falha ao cadastrar secretaria!" });
            }

        }

        public IActionResult ListOfRegisteredSecretaries(string q, int pages = 1) /*Only ADMIN*/
        {
            // Retorna a view de secretarias cadastradas em uma tabela com todos os registros inseridos na tabela de secretarias e recebe dois parâmetros que serão responsáveis pela busca filtrada de secretarias através do campo de busca que se encontra na view de listagem e um iniciador para a paginação dos registros cadastrados que criará os links para navegação entre as páginas de registros.

            Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
            Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

            int secretariesPerPage = 10; // variável que atribui o valor de registros a serem mostrados por página

            SecretariesService ss = new SecretariesService(); // instância da classe de SecretariesService 

            if (q == null) // verfica se o parâmetro de busca possui valor nulo.
            {
                q = string.Empty; // se a verificação retornar true, o parâmetro será atribuido como um string.Empty ou seja, um campo vazio apto a receber strings.
            }

            int secretariesQuantity = ss.CountRegister(); // chamada do método CountRegister de SecretariesServices que retorna o número de registros presentes na tabela de secretarias e atribui o valor à variável secretariesQuantity.

            ViewData["pageQuantity"] = (int)Math.Ceiling((double)secretariesQuantity / secretariesPerPage); // Cálculo da quantidade de páginas geradas pelo número total de registros, o ViewData irá armazenar esse valor para que seja gerado os links de navegação entr páginas na view de listagem.

            ICollection<Secretaries> secretaryList = ss.GetSecretary(q, pages, secretariesPerPage); // coleção de secretarias que chama pelo método GetSecretary de SecretariesService e recebe como parâmetros a string de pesquisa, a quantidade de páginas e a quantidade de secretarias por página e atribui seus valores ao objeto criado.

            return View(secretaryList); // retorna a view carregada com o objeto da coleção.
        }

        [HttpPost]
        public IActionResult UpgradeSecretary(Secretaries upgradeSecretary) /*Only ADMIN*/
        {
            // A edição de secretarias é feita através de uma partial view que é renderizada em um modal, que possui o formulário que recebe os dados de edição e os submete à esse método da controller de secretarias. O método recebe por parâmetro um objeto de secretarias que será utilizado para relaizar a edição com base no id clicado.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                new SecretariesService().SecretaryUpgrade(upgradeSecretary); // chamada do método SecretaryUpgrade de SecretariesService que realiza a edição do registro selecionado com base no objeto que é recebido como parâmetro.

                return RedirectToAction("ListOfRegisteredSecretaries", "Secretaries"); // Redireciona para a action de Listagem de secretarias.

            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Editar Secretaria !" + e.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public IActionResult DeleteSecretary(string decision, Secretaries deleteSecreatry) /*Only ADMIN*/
        {
            // A exclusão de secretarias é renderizada em um modal através de uma partial view, a exclusão acontece com base em uma estrutura de decisão que verifica se usuário opta por realmente excluir a secretaria após o aviso de exclusão que é mostrado ao escolher a opção de excluir, ou a opção cancelar que o redireciona de volta para a listagem de secretarias.

            try
            {

                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                SecretariesService ss = new SecretariesService(); // instância da classe de SecretariesService 

                switch (decision) // Estrutura de decisão que irá verificar a opção clicada pelo usuário e retornará a decisão de acordo com a opção clicada.
                {
                    case "Delete":

                        // chama o método de exclusão de secretarias e que deleta o registro com base no id selecionado.

                        ss.DeleteSecretaries(deleteSecreatry.Id);
                        return RedirectToAction("ListOfRegisteredSecretaries", "Secretaries"); // redireciona para a action de listagem de secretarias.

                    case "Cancel":
                        // apenas redireciona o usuário de volta à página de de listagem de secretarias.
                        return RedirectToAction("ListOfRegisteredSecretaries", "Secretaries");
                }

                return View(deleteSecreatry);
            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Excluir Secretaria !" + e.Message);
                return RedirectToAction("Login", "Home");

            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}