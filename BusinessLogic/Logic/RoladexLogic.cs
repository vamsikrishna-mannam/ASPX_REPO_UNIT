using System.Collections.Generic;
using BusinessEntities.Entities;
using BusinessEntities.Interfaces;
using DataLayer.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace BusinessLogic.Logic
{
    public class RoladexLogic : IRoladexLogic
    {
        private IRoladexRepository data;
        public RoladexLogic()
        {
            var dependencyContainer = new UnityContainer().LoadConfiguration();
            data = dependencyContainer.Resolve<IRoladexRepository>();
        }

        public RoladexLogic(IRoladexRepository roladexRepository)
        {
            data = roladexRepository;
        }
        public void Add(Roladex roladex)
        {
            data.Add(roladex);
        }

        public void DeleteItem(int id)
        {
            data.DeleteItem(id);
        }

        public Roladex GetItem(int id)
        {
            return data.GetItem(id);
        }

        public List<Roladex> GetItems()
        {
            return data.GetItems();
        }

        public void Dispose()
        {
            data.Dispose();
        }
    }
}
