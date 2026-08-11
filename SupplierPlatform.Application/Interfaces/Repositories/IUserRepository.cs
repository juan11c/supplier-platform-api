using SupplierPlatform.Domain.Entities;

namespace SupplierPlatform.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
}