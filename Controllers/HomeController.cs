using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSis.DataBase;
using WebSis.Identity;
using WebSis.Models;

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

                WebSisContext db = new WebSisContext();

                IQueryable<Users> userFound = db.Users.Where(u => u.Login == login || u.Password == password);

                int secretaryOfUser = userFound.Select(u => u.SecretariesId).FirstOrDefault();

                string LoginUser = userFound.Select(u => u.Login).FirstOrDefault();

                string PasswordUser = userFound.Select(u => u.Password).FirstOrDefault();

                string EncryptedPassword = Cryptography.EncryptedText(password);

                if ( secretaryId == -1)
                {
                    ViewData["ErrorLogin"] = "Selecione sua secretaria !";
                    HttpContext.Session.Clear();
                    return View(); 
                }
                
                if (secretaryOfUser != secretaryId)
                {
                    
                    ViewData["ErrorLogin"] = "A secretaria selecionada não corresponde a este usuário !";
                    HttpContext.Session.Clear();
                    return View(); 
                    
                }
                
                if (LoginUser != login || PasswordUser != EncryptedPassword)
                {
                    ViewData["ErrorLogin"] = "Login ou senha inválidos !";
                    HttpContext.Session.Clear();
                    return View();
                    

                } 
                
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception e)
            {

                _logger.LogError("Erro ao Realizar Login!" + e.Message);
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
