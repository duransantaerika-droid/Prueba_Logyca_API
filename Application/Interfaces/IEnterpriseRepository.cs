using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IEnterpriseRepository
    {
        Task<List<Enterprise>> GetAll();
        Task<Enterprise> GetById(int id);
        Task<Enterprise> GetByNit(long nit);
        Task Add(Enterprise enterprise);
        Task Update(Enterprise enterprise);
    }
}
