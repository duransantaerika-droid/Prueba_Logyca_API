using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CodeRepository : ICodeRepository
    {
        private readonly AppDbContext _context;

        public CodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Code> GetById(int id)
        {
            return await _context.Codes               
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Code>> GetByEnterprise(int enterpriseId)
        {
            return await _context.Codes
                .Where(c => c.Owner == enterpriseId)
                .ToListAsync();
        }

        public async Task Add(Code code)
        {
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Code code)
        {
            _context.Codes.Update(code);
            await _context.SaveChangesAsync();
        }
    }
}
