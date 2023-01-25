using System;
using System.Collections.Generic;
using System.Linq;
using WebSis.DataBase;
using WebSis.Models;

namespace WebSis.Services
{
    public class UsersService
    {
        public void CreateUserRegister(Users newUser)
        {

            using WebSisContext dataBase = new WebSisContext();

            newUser.Id.ToString("D4");
            newUser.Password = Cryptography.EncryptedText(newUser.Password);
            newUser.CheckedPassword = Cryptography.EncryptedText(newUser.CheckedPassword);

            dataBase.Users.Add(newUser);
            dataBase.SaveChanges();

        }

        public Users SearchUserForId(int id)
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.Users.Find(id);
        }

        public ICollection<Users> ListAndFilterUsers(string q, int page, int size)
        {
            using WebSisContext dataBase = new WebSisContext();

            int jump = (page - 1) * size;

            IQueryable<Users> query = dataBase.Users.Where(u => u.Name.Contains(q, StringComparison.OrdinalIgnoreCase));

            if (q != null)
            {
                query = query.OrderBy(u => u.Name);
            }

            return query.Skip(jump).Take(size).ToList();
        }

        public void EditUsers(Users editedUser)
        {
            using WebSisContext dataBase = new WebSisContext();

            Users u = dataBase.Users.Find(editedUser.Id);

            u.Name = editedUser.Name;
            u.Login = editedUser.Login;
            u.Password = Cryptography.EncryptedText(editedUser.Password);
            u.CheckedPassword = Cryptography.EncryptedText(editedUser.CheckedPassword);
            u.Type = editedUser.Type;
            dataBase.SaveChanges();
        }

        public void DeleteUsers(int id)
        {
            using WebSisContext dataBase = new WebSisContext();

            Users userFound = dataBase.Users.Find(id);

            dataBase.Users.Remove(userFound);
            dataBase.SaveChanges();
        }

        public int CountRegister()
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.Users.Count();
        }

    }
}