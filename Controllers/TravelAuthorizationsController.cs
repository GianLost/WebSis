using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSis.Identity;
using WebSis.Models;
using WebSis.Services;

namespace WebSis.Controllers
{
    // Controller responsável pelas requisições de registro, edição, listagem, exclusão e geração do relatório pdf de TA.

    public class TravelAuthorizationsController : Controller
    {
        private readonly ILogger<TravelAuthorizationsController> _logger; // instância do objeto da interface ILogger que gerenciará os logs.
        private readonly IWebHostEnvironment _enviroment; // Instância do objeto de IWebHostEnvironment para obter os caminhos de diretórios do projeto.
        private readonly TravelAuthorizationsService _TravelAuthorizationsService; // Instância do objeto de TravelAuthorizationsService para obter as propriedades necessárias para gerar o pdf de TA.

        public TravelAuthorizationsController(ILogger<TravelAuthorizationsController> logger, IWebHostEnvironment enviroment, TravelAuthorizationsService travelAuthorizationsService)
        {
            _logger = logger; // injeção de dependência do objeto de logs da biblioteca Serilog utilizando a interface ILogger.
            _enviroment = enviroment; // injeção de dependência do objeto de IWebHostEnvironment.
            _TravelAuthorizationsService = travelAuthorizationsService; // injeção de dependência do objeto de _TravelAuthorizationsService.
        }

        [HttpPost]
        public IActionResult RegisterTA(TravelAuthorizations newTravel)
        {
            // O registro de TA é feito através de uma partial view que é renderizada em um modal dentro da view index de Home. A partial view mostra um formulário que abre junto ao modal e a requisição é feita por este método de UsersController. O método recebe um objeto de usuário como parâmetro e chama um método de UsersService que salva os dados inseridos e logo após redireciona para uma ação.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.

                TravelAuthorizationsService ts = new TravelAuthorizationsService(); // Instância da classe TravelAuthorizationsService.

                ts.AddTA(newTravel); // chamada do método AddTA de TravelAuthorizationsService que realiza a edição do registro selecionado com base no objeto que é recebido como parâmetro

                return RedirectToAction("Index", "Home"); // Redireciona para a action Index de Home.


            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Criar formulário de Autorização de viagem!" + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult ListAllTravels(string q, int pages = 1) /*Only ADMIN*/
        {
            // Retorna a view de TA cadastrados em uma tabela com todos os registros inseridos na tabela de TA e recebe dois parâmetros que serão responsáveis pela busca filtrada das TA através campo de busca que se encontra na view de listagem e um iniciador para a paginação dos registros cadastrados que criará os links para navegação entre as páginas de registros.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                int travelsPerPage = 10; // variável que atribui o valor de registros a serem mostrados por página

                TravelAuthorizationsService tas = new TravelAuthorizationsService(); // instância da classe de TravelAuthorizationsService 

                if (q == null) // verfica se o parâmetro de busca possui valor nulo.
                {
                    q = string.Empty; // se a verificação retornar true, o parâmetro será atribuido como um string.Empty ou seja, um campo vazio apto a receber strings.
                } 

                int registersQuantity = tas.CountRegister(); // chamada do método CountRegister de TravelAuthorizationsService que retorna o número de registros presentes na tabela de TA e atribui o valor à variável secretariesQuantity.

                ViewData["pageQuantity"] = (int)Math.Ceiling((double)registersQuantity / travelsPerPage);

                ICollection<TravelAuthorizations> travelList = tas.ListAllTA(q, pages, travelsPerPage); // coleção de autorização de viagem que chama pelo método ListAllTA de TravelAuthorizationsService e recebe como parâmetros a string de pesquisa, a quantidade de páginas e a quantidade de secretarias por página e atribui seus valores ao objeto criado.

                return View(travelList); // retorna a view carregada com o objeto da coleção travelList.
            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Listar todos Av's cadastrados!" + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

         public IActionResult ListTAPerSecretary(string q, int pages = 1) /*Only ADMIN*/
        {
            // Retorna a view de TA cadastrados em uma tabela com todos relativos à secretaria do usuário logado na sessão.O método controlador recebe dois parâmetros que serão responsáveis pela busca filtrada das TA através campo de busca que se encontra na view de listagem e um iniciador para a paginação dos registros cadastrados que criará os links para navegação entre as páginas de registros.

            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.

                int travelsPerPage = 10; // variável que atribui o valor de registros a serem mostrados por página

                TravelAuthorizationsService tas = new TravelAuthorizationsService(); // instância da classe de TravelAuthorizationsService 

                if (q == null) // verfica se o parâmetro de busca possui valor nulo.
                {
                    q = string.Empty; // se a verificação retornar true, o parâmetro será atribuido como um string.Empty ou seja, um campo vazio apto a receber strings.
                } 

                int registersQuantity = tas.CountRegister(); // chamada do método CountRegister de TravelAuthorizationsService que retorna o número de registros presentes na tabela de TA e atribui o valor à variável secretariesQuantity.

                ViewData["pageQuantity"] = (int)Math.Ceiling((double)registersQuantity / travelsPerPage); // Cálculo da quantidade de páginas geradas pelo número total de registros, o ViewData irá armazenar esse valor para que seja gerado os links de navegação entr páginas na view de listagem.

                ICollection<TravelAuthorizations> travelList = tas.ListAllTA(q, pages, travelsPerPage).Where(ta => ta.SecretariesId == HttpContext.Session.GetInt32("secretariesId")).ToList(); // coleção de autorização de viagem que chama pelo método ListAllTA de TravelAuthorizationsService e recebe como parâmetros a string de pesquisa, a quantidade de páginas e a quantidade de secretarias por página e atribui seus valores ao objeto criado.

                return View(travelList); // retorna a view carregada com o objeto da coleção travelList.
            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Listar Av's cadastrados po secretaria!" + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult TACreateReport() /*Only ADMIN*/
        {
            // O método TACreateReport utiliza o framework FastReporter para gerar um arquivo de Report que será usado para gerar o pdf com dados do banco em um arquivo modelo presente em /wwwroot/pdf/TAReports.frx.
            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this); // utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                string reportFile = Path.Combine(_enviroment.WebRootPath, @"pdf\TAReports.frx"); //string que armazena o diretório (caminho) do arquivo de report do FastReporter.

                FastReport.Report r = new FastReport.Report(); // instância da classe de FastReport.Report

                ICollection<TravelAuthorizations> travelsList = _TravelAuthorizationsService.ListTravels(); // coleção de TA que chama pelo método ListTravels de TravelAuthorizationsService e que retorna uma listagem de registros presentes na tabela de TA.

                r.Report.Dictionary.RegisterBusinessObject(travelsList, "travelsList", 10, true);

                r.Report.Save(reportFile);

                return Ok($"OK! {reportFile}");

            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Gerar Report via FastReporter !" + e.Message);
                return RedirectToAction("Login", "Home");

            }
        }

        [HttpGet]
        public IActionResult TAPrintToPdf(int id)
        {
            // O método TAPrintToPdf recebe um id por parâmetro que será o id para retornar os registros do relatório clicado com base no id, e utiliza um memory stream junto com o arquivo de report do FastReporter para retornar um arquivo em formato PDF que será renderizado pelo leitor nativo de PDF do navegador usado.
            try
            {
                Authentication.CheckLogin(this); // utilizando a classe Authentication para verificar se a sessão está estabelecida.

                string reportFile = Path.Combine(_enviroment.WebRootPath, @"pdf\TAReports.frx"); //string que armazena o diretório (caminho) do arquivo de report do FastReporter.

                FastReport.Report r = new FastReport.Report(); // instância da classe de FastReport.Report
                
                ICollection<TravelAuthorizations> travelsList = _TravelAuthorizationsService.ListTravelsForId(id); // coleção de TA que chama pelo método ListTravelsForId de TravelAuthorizationsService e que retorna uma listagem de registros da tabela TA baseados no Id passado por parâmetro.

                r.Report.Load(reportFile); // Carregamento da string que contem o caminho do arquivo de report.
                r.Report.Dictionary.RegisterBusinessObject(travelsList, "travelsList", 10, true);
                r.Prepare(); // Preparando o report.

                PDFSimpleExport pdfExport = new PDFSimpleExport(); // instância da classe PDFSimpleExport
                using MemoryStream ms = new MemoryStream(); // instancando um memory stream 

                pdfExport.Export(r, ms); // chamada do método export de PDFSimpleExport que recebe o objeto de FastReport.Report e  o memory stram para processar os bytes do arquivo.

                ms.Flush(); // inibe a execução de uma ação durante o processamento dos bytes da exportação.

                return File(ms.ToArray(), "application/pdf"); // retorna um arquivo no formato PDF.

            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Gerar AV PDF !" + e.Message);
                return RedirectToAction("Login", "Home");

            }

        }

        [HttpPost]
        public IActionResult DeleteTA(string decision, TravelAuthorizations deleteTA) /*Only ADMIN*/
        {
            // A exclusão de TA é renderizada em um modal através de uma partial view, a exclusão acontece com base em uma estrutura de decisão que verifica se usuário opta por realmente excluir a secretaria após o aviso de exclusão que é mostrado ao escolher a opção de excluir, ou a opção cancelar que o redireciona de volta para a listagem de secretarias.

            try
            {

                Authentication.CheckLogin(this);// utilizando a classe Authentication para verificar se a sessão está estabelecida.
                Authentication.CheckIfUserIsAdministrator(this);// utilizando a classe Authentication para verificar o usuário na sessão corresponde à um usuário administrador.

                TravelAuthorizationsService tas = new TravelAuthorizationsService(); // instância da classe de SecretariesService 

                switch (decision) // Estrutura de decisão que irá verificar a opção clicada pelo usuário e retornará a decisão de acordo com a opção clicada.
                {

                    case "Delete":

                        // chama o método de exclusão de secretarias e que deleta o registro com base no id selecionado.

                        tas.TADelete(deleteTA.Id); // chamada do método TADelete que recebe um id para excluir com base no id clicado.
                        return RedirectToAction("Index", "Home");// redireciona para a action de listagem de secretarias.

                    case "Cancel":

                        // apenas redireciona o usuário de volta à página de de listagem de secretarias.
                        return RedirectToAction("Index", "Home");

                }

                return View(deleteTA);
            }
            catch (Exception e)
            {
                // caso uma excessão seja gerada o usuário é redirecionado para a página de login e o gerenciador de LOG's irá registrar a execessão junto à mensagem de erro em um novo LOG. 
                _logger.LogError("Erro ao Excluir AV !" + e.Message);
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