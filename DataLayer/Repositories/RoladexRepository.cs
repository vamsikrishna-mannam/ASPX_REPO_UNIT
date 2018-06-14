using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Database;
using DataLayer.Interfaces;
using Entities = BusinessEntities.Entities;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class RoladexRepository : RepositoriesBaseClass<Roladex, Entities.Roladex>,  IRoladexRepository
    {
     //   private Func<Roladex, bool> isCompany = delegate (Roladex r) { return r.Company == "Test"; };
        public void Add(Entities.Roladex roladex)
        {
            
            if (roladex != null)
            {
                var dataEntity = AsDataObject(roladex);
                dataContext.Entry(dataEntity).State = EntityState.Added;
                dataContext.Roladexes.Add(dataEntity);
                dataContext.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Entities.Roladex GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Roladex> GetItems()
        {

            var dataEntities = dataContext.Roladexes.ToList();
            var businessEntities = new List<Entities.Roladex>();
            foreach(var dataEntity in dataEntities)
            {
                businessEntities.Add(AsBusinessObject(dataEntity));
            }
            return businessEntities;
        }
    }
}
