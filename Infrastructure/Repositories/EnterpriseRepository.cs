using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly AppDbContext _context;

        public EnterpriseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enterprise>> GetAll()
        {
            return await _context.Enterprises.ToListAsync();
        }

        public async Task<Enterprise> GetById(int id)
        {
            return await _context.Enterprises
                .Include(e => e.Codes)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Enterprise> GetByNit(long nit)
        {
            return await _context.Enterprises
                .Include(e => e.Codes)
                .FirstOrDefaultAsync(e => e.Nit == nit);
        }

        public async Task Add(Enterprise enterprise)
        {
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Enterprise enterprise)
        {
            _context.Enterprises.Update(enterprise);
            await _context.SaveChangesAsync();
        }
    }
}
