using SupplierPlatform.Application.DTOs.Suppliers;
using SupplierPlatform.Application.Interfaces;
using SupplierPlatform.Application.Interfaces.Repositories;
using SupplierPlatform.Domain.Entities;
using SupplierPlatform.Domain.Enums;

namespace SupplierPlatform.Application.Services.Suppliers;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUserRepository _userRepository;
    private readonly IClaimTokenGenerator _tokenGenerator;

    public SupplierService(ISupplierRepository supplierRepository, IUserRepository userRepository, IClaimTokenGenerator tokenGenerator)
    {
        _supplierRepository = supplierRepository;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<SupplierResponseResponse> CreateUnclaimedSupplierAsync(CreateSupplierRequest dto)
    {
        var token = _tokenGenerator.GenerateToken();

        var supplier = new SupplierProfile
        {
            BusinessName = dto.BusinessName,
            Description = dto.Description,
            Phone = dto.Phone,
            Address = dto.Address,
            Status = ProfileStatus.Unclaimed,
            ClaimToken = token,
            ClaimTokenExpiresAt = DateTime.UtcNow.AddDays(30)
        };

        await _supplierRepository.AddAsync(supplier);

        return new SupplierResponseResponse(
            supplier.Id,
            supplier.BusinessName,
            supplier.Description,
            supplier.Phone,
            supplier.Address,
            supplier.Status.ToString(),
            supplier.ClaimToken
        );
    }

    public async Task<bool> ClaimSupplierProfileAsync(ClaimProfileRequest dto)
    {
        var supplier = await _supplierRepository.GetByClaimTokenAsync(dto.ClaimToken);

        if (supplier == null || supplier.ClaimTokenExpiresAt < DateTime.UtcNow)
        {
            return false; // Token inválido o expirado
        }

        // Crear la cuenta de usuario vinculada
        var newUser = new User
        {
            Email = dto.Email,
            PasswordHash = dto.Password, // En Infrastructure se aplicará el Hash seguro (BCrypt/Argon2)
            Role = UserRole.Supplier,
            IsActive = true
        };

        // 1. Registrar primero el usuario en la BD para generar la referencia real
        await _userRepository.AddAsync(newUser);

        // 2. Asociar el UserId y actualizar el estado del perfil
        supplier.UserId = newUser.Id;
        supplier.Status = ProfileStatus.Active;
        supplier.ClaimToken = null;
        supplier.ClaimTokenExpiresAt = null;

        await _supplierRepository.UpdateAsync(supplier);
        return true;
    }
}