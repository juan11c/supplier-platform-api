using SupplierPlatform.Domain.Entities;

namespace SupplierPlatform.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<SupplierProfile?> GetByIdAsync(Guid id);
        Task<SupplierProfile?> GetByClaimTokenAsync(string token);
        Task AddAsync(SupplierProfile supplier);
        Task UpdateAsync(SupplierProfile supplier);
    }
}
