using System;
using System.Collections.Generic;
using BusinessEntities.Entities;
namespace BusinessEntities.Interfaces
{
    public interface IRoladexLogic:IDisposable
    {
        List<Roladex> GetItems();
        Roladex GetItem(int id);
        void Add(Roladex roladex);
        void DeleteItem(int id);
    }
}
