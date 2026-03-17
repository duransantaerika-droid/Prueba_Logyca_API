using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICodeRepository
    {
        Task<Code> GetById(int id);
        Task<List<Code>> GetByEnterprise(int enterpriseId);
        Task Add(Code code);
        Task Update(Code code);
    }
}
