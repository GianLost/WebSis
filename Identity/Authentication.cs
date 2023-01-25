using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSis.DataBase;
using WebSis.Models;

namespace WebSis.Identity
{
    // A classe de Authenticação pertencente à Identity é responsável por estabelecer, realizar validações e controlar uma sessão.
    public static class Authentication
    {
        public static void CheckLogin(Controller controller)
        {
            // O método CheckLogin recebe por parâmetro um objeto de controller e realiza uma verificação no contexto Http da sessão.

            if (string.IsNullOrEmpty(controller.HttpContext.Session.GetString("login"))) // recebe a variável de sessão "login" e valida se é nula ou vazia.
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login"); // ao retornar true o método redireciona o usuário novamente para a página de login.
            }
        }

        public static bool CheckLoginAndPassword(string login, string password, int secretaryId, Controller controller)
        {
            // O método CheckLoginAndPassword recebe por parâmetro um objeto de Controller, uma string que corresponderá ao nome de login do usuário e uma string correspondente à senha do usuário e valida os campos inseridos com base em uma pesquisa na tabela de registros de usuário.

            using WebSisContext dataBase = new WebSisContext(); // Instância de WebSisContext, classe que armazena a conexão com o banco de dados;

            Users u = new Users();
            //CheckCounterSecretary(dataBase, secretaryId, controller);

            CheckIfUserAdministratorExist(dataBase, secretaryId); // Chamada do método que verifica se existe um usuário administrador e que se caso não existir cria um novo;

            string PasswordUser = Cryptography.EncryptedText(password); // Transforma em Hash MD5 a string digitada no campo de senha no momento do login;

            IQueryable<Secretaries> Secretary = dataBase.Secretaries.Where(s => s.Id == secretaryId);

            List<Secretaries> SecretaryFound = Secretary.ToList();

            IQueryable<Users> userFound = dataBase.Users.Where(searchForUser => searchForUser.Login == login || searchForUser.Password == PasswordUser || searchForUser.SecretariesId == secretaryId); // Armazena no objeto userFound uma pesquisa que avalia se os dados de login e senha digitados são correspondentes aos que estão presentes no banco de dados;

            List<Users> foundUserList = userFound.ToList(); // Criando uma lista com os registros buscados para armazenar dados da sessão.

            if (foundUserList.Count == 0) // Estrutura de verificação que irá verificar a contagem de registros presente na lista de usuários encontrados.
            {
                return false; // Retorna false se a condição for true
            }else if ( secretaryId == -1)
            {
                return false;
            }else
            {

                // Dados armazenados na sessão

                controller.HttpContext.Session.SetString("login", foundUserList[0].Login);
                controller.HttpContext.Session.SetString("name", foundUserList[0].Name);
                controller.HttpContext.Session.SetInt32("type", foundUserList[0].Type);
                controller.HttpContext.Session.SetInt32("idUser", foundUserList[0].Id);
                controller.HttpContext.Session.SetInt32("secretariesId", foundUserList[0].SecretariesId);

                controller.HttpContext.Session.SetString("secretaryName", SecretaryFound[0].Name);
                controller.HttpContext.Session.SetString("secretaryAcronym", SecretaryFound[0].Acronym);

                return true;
            }

        }
        /*private static void CheckCounterSecretary(WebSisContext dataBase, int secretaryId, Controller controller)
        {
            int secretaryFound = dataBase.Secretaries.Count();

            if(secretaryFound == 0)
            {
                Secretaries secretary = new Secretaries();

                secretary.Name = "Secretaria Municipal de Administração";
                secretary.Acronym = "SEMAD";
                dataBase.Secretaries.Add(secretary);
                dataBase.SaveChanges();
            }

            if (secretaryId == -1)
            {
                string secretary = secretaryId.ToString();

                secretary = "SEMAD";
            }
        }*/

        private static void CheckIfUserAdministratorExist(WebSisContext dataBase, int secretaryId)
        {
            // CheckIfUserAdministratorExist verifica através de uma pesquisa se existe um usuário administrador para que a sessão seja estabelecida de acordo com o nível do usuário. Caso não exista um usuário administrador criado, o método criará um usuário administrador padronizado para obter um acesso à sessão.

            int secretaryFound = dataBase.Secretaries.Count();

            if(secretaryFound == 0)
            {
                Secretaries secretary = new Secretaries();

                secretary.Name = "Secretaria Municipal de Administração";
                secretary.Acronym = "SEMAD";
                dataBase.Secretaries.Add(secretary);
                dataBase.SaveChanges();
            }

            IQueryable<Secretaries> getSecretaryId = dataBase.Secretaries.Where( u => u.Acronym == "SEMAD");

            int IdsecretaryOfUser = getSecretaryId.Select(u => u.Id).FirstOrDefault();

            if (secretaryId == -1)
            {
                secretaryId = IdsecretaryOfUser;

                
            }

            IQueryable<Users> userFound = dataBase.Users.Where(searchForUser => searchForUser.Type == 1); // Busca pelo identificador (Tipo) para verificar se existe um usuário administrador ou não;

            if (userFound.ToList().Count == 0) // Faz uma verificação da contagem de registros do objeto userFound.
            {
                //Cria usuário admin automático casa não exista um com base nas atribuições abaixo caso a verificação retorne true.

                Users admin = new Users(); // Intância da classe de modelo Usuários.

                IQueryable<Secretaries> adminSecretaryId = dataBase.Secretaries.Where( u => u.Acronym == "SEMAD");

                int secretaryOfUser = adminSecretaryId.Select(u => u.Id).FirstOrDefault();

                admin.Name = "Administrator";
                admin.Login = "admin";
                admin.Password = "21232f297a57a5a743894a0e4a801fc3";
                admin.CheckedPassword = "21232f297a57a5a743894a0e4a801fc3";
                admin.Type = Users.ADMIN;

                admin.SecretariesId = secretaryOfUser;

                dataBase.Users.Add(admin); // Adiciona o registro à tabela de usuarios no contexto do banco de dados.
                dataBase.SaveChanges(); // Salva as alterações feitas.
            }
        }

        public static void CheckIfUserIsAdministrator(Controller controller)
        {
            // CheckIfUserIsAdministrator verifica na sessão estabelecida a variável de sessão "type" para certificar que o usuário solicitando conexão é administrador, uma vez que a sessão obedece à uma hierarquia de níveis de usuário para que as requisições sejam feitas de acordo com cada tipo de usuário que possuem acessos distintos.

            if (!(controller.HttpContext.Session.GetInt32("type") == Users.ADMIN)) // verificação que retorna se o usuário tentando estabelecer conexão não é administrador.
            {
                controller.HttpContext.Session.Clear(); // se a verificação retornar true os dados da tentativa de conexão serão limpos.
                controller.Request.HttpContext.Response.Redirect("/Home/Login"); // Redireciona o usuário para a página de login para que reestabeleça uma conexão de acordo com seu nível de acesso.
            }
        }
    }
}