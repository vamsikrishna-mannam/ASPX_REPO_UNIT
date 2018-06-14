using System;
using System.Collections.Generic;
using Entities = BusinessEntities.Entities;

namespace DataLayer.Interfaces
{
    public interface IRoladexRepository: IDisposable
    {
        List<Entities.Roladex> GetItems();
        Entities.Roladex GetItem(int id);
        void Add(Entities.Roladex roladex);
        void DeleteItem(int id);
    }
}
