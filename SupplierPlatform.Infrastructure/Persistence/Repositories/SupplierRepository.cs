using Microsoft.EntityFrameworkCore;
using SupplierPlatform.Application.Interfaces.Repositories;
using SupplierPlatform.Domain.Entities;

namespace SupplierPlatform.Infrastructure.Persistence.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _context;

    public SupplierRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SupplierProfile?> GetByIdAsync(Guid id)
    {
        return await _context.SupplierProfiles
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<SupplierProfile?> GetByClaimTokenAsync(string token)
    {
        return await _context.SupplierProfiles
            .FirstOrDefaultAsync(s => s.ClaimToken == token);
    }

    public async Task AddAsync(SupplierProfile supplier)
    {
        await _context.SupplierProfiles.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SupplierProfile supplier)
    {
        _context.SupplierProfiles.Update(supplier);
        await _context.SaveChangesAsync();
    }
}