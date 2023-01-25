using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSis.Identity;
using WebSis.Models;
using WebSis.Services;

namespace WebSis.Controllers
{
    // Controller responsável pelas requisições de registro, listagem, exclusão e edição de Usuários.

    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger; // instância do objeto da interface ILogger que gerenciará os logs.

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger; // injeção de dependência do objeto de logs da biblioteca Serilog utilizando a interface ILogger.
        }

        [HttpPost]
        public IActionResult RegisterUser(Users newRegisterUser) /*Only ADMIN*/
        {
            // O cadastro de usuários é feito através de uma partial view que é renderizada em um modal que traz o formulário de cadastro, a requisição do cadastro de usuários é feita de forma assíncrona utilizando Ajax através da biblioteca JQuery do Js.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                UsersService us = new UsersService(); // instância da classe de UsersService. 

                us.CreateUserRegister(newRegisterUser); // chamada do método presente em UsersService que salva os dados que foram inseridos no banco de dados recebidos através do objeto de usuário passado como parâmetro no método de registro

                return Json(new { stats = "OK" }); // retorna um arquivo Json que seta um status para a controller.

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Cadastrar Usuário!" + e.Message);
                return Json(new { stats = "ERROR", message = "Falha ao cadastrar usuário!" }); // Caso a requisição falhe um status de erro é setado ao arquivo Json.
            }
        }

        public IActionResult ListOfRegisteredUsers(string q, int pages = 1) /*Only ADMIN*/
        {
            // Retorna a view de usuários cadastrados em uma tabela com todos os registros inseridos na tabela de usuários e recebe dois parâmetros que serão responsáveis pela busca filtrada de secretarias através campo de busca que se encontra na view de listagem e um iniciador para a paginação dos registros cadastrados que criará os links para navegação entre as páginas de registros.
            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                int usersPerPage = 8; // variável que atribui o valor de registros a serem mostrados por página

                UsersService us = new UsersService(); // instância da classe de UsersService 

                if (q == null) // verfica se o parâmetro de busca possui valor nulo.
                { 
                    q = string.Empty; // se a verificação retornar true, o parâmetro será atribuido como um string.Empty ou seja, um campo vazio apto a receber strings.
                }

                int registersQuantity = us.CountRegister(); // chamada do método CountRegister de UsersServices que retorna o número de registros presentes na tabela de usuários e atribui o valor à variável registersQuantity.

                ViewData["pageQuantity"] = (int)Math.Ceiling((double)registersQuantity / usersPerPage);

                ICollection<Users> usersList = us.ListAndFilterUsers(q, pages, usersPerPage); // coleção de usuários que chama pelo método ListAndFilterUsers de UsersService e recebe como parâmetros a string de pesquisa, a quantidade de páginas e a quantidade de usuários por página e atribui seus valores ao objeto usersList criado.

                return View(usersList); // retorna a view carregada com o objeto da coleção
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Listar Usuários cadastrados!" + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpdateUser(Users editUser) /*Only ADMIN*/
        {
            // A edição de usuários é feita através de uma partial view que é renderizada em um modal, que possui o formulário que recebe os dados de edição e os submete à esse método da controller de usuários. O método recebe por parâmetro um objeto de Users que será utilizado para relaizar a edição com base no id clicado.

            try
            {

                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                new UsersService().EditUsers(editUser); // chamada do método EditUsers de UsersService que realiza a edição do registro selecionado com base no objeto editUser que é recebido como parâmetro.

                return RedirectToAction("ListOfRegisteredUsers", "Users");
                //return Json(new { upstats = "OK" });

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Editar a Usuário !" + e.Message);
                return RedirectToAction("Login", "Home");
                //return Json(new { upstats = "ERROR", upmessage = "Falha ao cadastrar usuário!" });
            }
        }

        [HttpPost]
        public IActionResult DeleteUser(string decision, Users deleteuser) /*Only ADMIN*/
        {
            // A exclusão de usuários é renderizada em um modal através de uma partial view, a exclusão acontece com base em uma estrutura de decisão que verifica se usuário opta por realmente excluir o usuário após o aviso de exclusão que é mostrado ao escolher a opção de excluir, ou a opção cancelar que o redireciona de volta para a listagem de usuário.

            try
            {

                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                UsersService us = new UsersService(); // instância da classe de UsersService 

                switch (decision) // Estrutura de decisão que irá verificar a opção clicada pelo usuário e retornará a decisão de acordo com a opção clicada.
                {

                    case "Delete":

                        // chama o método de exclusão de usuários e que deleta o registro com base no id selecionado.

                        us.DeleteUsers(deleteuser.Id);
                        return RedirectToAction("ListOfRegisteredUsers", "Users");

                    case "Cancel": 

                        // apenas redireciona o usuário de volta à página de de listagem de usuários.
                        return RedirectToAction("ListOfRegisteredUsers", "Users");

                }

                return View(deleteuser);
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Excluir Usuário !" + e.Message);
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