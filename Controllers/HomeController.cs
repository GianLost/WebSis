using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSis.DataBase;
using WebSis.Identity;
using WebSis.Models;
using WebSis.Services;

/* Controller responsável pelas rotas da página inicial e página de login que valida os dados de usuário para estabelecer uma sessão com base nos métodos de Identity. */

namespace WebSis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // instância do objeto da interface ILogger que gerenciará os logs.

        public HomeController(ILogger<HomeController> logger)
        {
            // injeção de dependência do objeto de logs da biblioteca Serilog utilizando a interface ILogger.
            _logger = logger;
        }

        public IActionResult Index()
        {
            Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida
            return View();
        }

        public IActionResult Login()
        {
            // retorna a View que possui o formulário de login.
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password, int secretaryId)
        {
            // Faz o post dos dados enviados pelo formulário da view de login, recebendo como parâmetro o nome de login e a senha do usuário e estabelece a sessão com base nos dados inseridos se caso eles existirem, caso contrário irá barrar o acesso limitando apenas a página de login.

            try
            {

                Authentication.CheckLoginAndPassword(login, password, secretaryId, this);

                Users u = new Users();

                WebSisContext dataBase = new WebSisContext();

                IQueryable<Users> userFound = dataBase.Users.Where(u => u.Login == login || u.Password == password); // Busca na tabela de registro de usuários o usuário correspondente à pesquisa que compara login e senha informados pelo usuário no formulário de login.

                int secretaryOfUser = userFound.Select(u => u.SecretariesId).First(); // scretaryOfUser recebe uma seleção dentro do objeto query de user found que busca o Id da secretaria relacionada ao usuário.

                string LoginUser = userFound.Select(u => u.Login).First(); // seleciona através do objeto de pesquisa userFound o campo de Login que corresponde ao digitado pelo usuário vereficando se ele existe ou não.

                string PasswordUser = userFound.Select(u => u.Password).First(); // seleciona através do objeto de pesquisa userFound o campo de senha que corresponde ao digitado pelo usuário vereficando se ele existe ou não.

                string EncryptedPassword = Cryptography.EncryptedText(password); // Transforma em Hash MD5 a string digitada no campo de senha no momento do login;

                if (secretaryId == -1)
                {
                    // O valor -1 é atribuido ao campo do select que está selecionado para que seja verificado se o usuário selecionou ou não alguma secretaria. O combobox select é reponsável por conter os dados das secretarias que o usuário deve selecionar para realizar o login caso a estrutura de verificação retorne true a seção será limpa e o usuário terá uma mensagem de erro renderizada no formulário, informando que uma secretaria precisa ser selecionada para continuar com o login.

                    ViewData["ErrorLogin"] = "Selecione sua secretaria !";
                    HttpContext.Session.Clear();
                    return View();
                }

                if (secretaryOfUser != secretaryId)
                {
                    // Após verificar se uma secretaria foi selecionada, caso a primeira estrutura retorne false ela passa para a verificação que irá validar se a secretaria selecionada corresponde à secretaria que o usuário pertence. Caso a estrutura retorne true uma mensagem de erro será renderizada no formulário, informando que a secretaria selecionada não pertence à aquele usuário.

                    ViewData["ErrorLogin"] = "A secretaria selecionada não corresponde a este usuário !";
                    HttpContext.Session.Clear();
                    return View();

                }

                if (LoginUser != login || PasswordUser != EncryptedPassword)
                {
                    // Após verificar que o usuário selecionou uma secretaria e que a secretaria realmente corresponde á sua secretaria, o método verifica se os dados de login e senha informados existem no banco e se correspondem realmente à um usuário registrado, caso a verificação retorne true uma mensagem de erro será renderizada no formulário, informando que os dados de login ou senha estão incorretos pois não existem na base de dados.
                    ViewData["ErrorLogin"] = "Login ou senha inválidos !";
                    HttpContext.Session.Clear();
                    return View();


                }else
                {
                    // Caso as validações sejam satisfeitas o usuário obtém o próximo nível de acesso podendo adentrar à página inicial do sistema que recebe uma validação que verifica se o usuário estabeleceu uma conexão confiável e de acordo com as regras estabelecidas.
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception e)
            {
                // Caso uma execessão seja gerada um log é criado contendo as informações da excessão que é capturada plo objeto _ILogger e uma mensagem é gerada no console informando o erro gerado e contendo as informações configuradas no objeto de geração de Logs.

                _logger.LogError("Erro ao Realizar Login!" + e.Message);
                return RedirectToAction("Login", "Home");

            }

        }

        [HttpPost]
        public IActionResult UpgradeTA(TravelAuthorizations editTA) /*Only ADMIN*/
        {
            try
            {

                Authentication.CheckLogin(this); 
                Authentication.CheckIfUserIsAdministrator(this);

                new TravelAuthorizationsService().EditTA(editTA);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Editar a Usuário !" + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // limpa os dados da sessão.
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
