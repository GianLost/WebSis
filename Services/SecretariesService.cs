using System;
using System.Collections.Generic;
using System.Linq;
using WebSis.DataBase;
using WebSis.Models;

namespace WebSis.Services
{
    public class SecretariesService
    {
        public void AddSecretary(Secretaries newSecretary)
        {

            using WebSisContext database = new WebSisContext();

            database.Secretaries.Add(newSecretary);
            database.SaveChanges();

        }

        public List<Secretaries> SecretariesList()
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.Secretaries.ToList();
        }

        public Secretaries SecretariesList(int id)
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.Secretaries.Find(id);
        }

        public ICollection<Secretaries> GetSecretary(string q, int page, int size) // Método de paginação
        {
            using WebSisContext dataBase = new WebSisContext();

            int jump = (page - 1) * size;

            IQueryable<Secretaries> query = dataBase.Secretaries.Where(u => u.Acronym.Contains(q, StringComparison.OrdinalIgnoreCase) || u.Name.Contains(q, StringComparison.OrdinalIgnoreCase));

            if (q != null)
            {
                query = query.OrderBy(u => u.Acronym);
            }

            return query.Skip(jump).Take(size).ToList();

        }

        public void SecretaryUpgrade(Secretaries upgradeSecretary)
        {
            using WebSisContext dataBase = new WebSisContext();

            Secretaries u = dataBase.Secretaries.Find(upgradeSecretary.Id);
            u.Name = upgradeSecretary.Name;
            u.Acronym = upgradeSecretary.Acronym;

            dataBase.SaveChanges();
        }

        public void DeleteSecretaries(int id)
        {
            using WebSisContext dataBase = new WebSisContext();

            Secretaries FoundSecretary = dataBase.Secretaries.Find(id);

            dataBase.Secretaries.Remove(FoundSecretary);
            dataBase.SaveChanges();
        }

        public int CountRegister()
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.Secretaries.Count();

        }
    }
}