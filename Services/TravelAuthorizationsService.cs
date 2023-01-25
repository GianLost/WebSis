using System;
using System.Collections.Generic;
using System.Linq;
using WebSis.DataBase;
using WebSis.Models;

namespace WebSis.Services
{
    public class TravelAuthorizationsService
    {
        public void AddTA(TravelAuthorizations newTravel)
        {
            using WebSisContext dataBase = new WebSisContext();

            dataBase.TravelAuthorizations.Add(newTravel);
            dataBase.SaveChanges();
        }

        public void TADelete(int id)
        {
            using WebSisContext dataBase = new WebSisContext();

            TravelAuthorizations travelFound = dataBase.TravelAuthorizations.Find(id);

            dataBase.TravelAuthorizations.Remove(travelFound);
            dataBase.SaveChanges();
        }

        public ICollection<TravelAuthorizations> ListAndOrderTravels()
        {

            using WebSisContext dataBase = new WebSisContext();

            ICollection<TravelAuthorizations> query = dataBase.TravelAuthorizations.ToList();
            
            return query.OrderByDescending(u => u.Id).ToList();

        }

        public ICollection<TravelAuthorizations> ListAllTA(string q, int page, int size)
        {
            using WebSisContext dataBase = new WebSisContext();

            int jump = (page - 1) * size;

            IQueryable<TravelAuthorizations> query = dataBase.TravelAuthorizations.Where(u => u.ClientName.Contains(q, StringComparison.OrdinalIgnoreCase) || u.CurrentDate.Contains(q, StringComparison.CurrentCulture));

            if (q != null)
            {
                query = query.OrderByDescending(u => u.CurrentDate);
            }

            return query.Skip(jump).Take(size).ToList();
        }

        public List<TravelAuthorizations> ListTravelsForId(int id)
        {
            using WebSisContext dataBase = new WebSisContext();

            List<TravelAuthorizations> travelsList = new List<TravelAuthorizations>();
            TravelAuthorizations FoundedTravels = dataBase.TravelAuthorizations.Where(p => p.Id == id).SingleOrDefault();

            travelsList.Add(FoundedTravels);

            return travelsList;
        }

        public List<TravelAuthorizations> ListTravels()
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.TravelAuthorizations.ToList();
        }

        public TravelAuthorizations SearchTAForId(int id)
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.TravelAuthorizations.Find(id);
        }

        public int CountRegister()
        {
            using WebSisContext dataBase = new WebSisContext();
            return dataBase.TravelAuthorizations.Count();

        }
    }
}