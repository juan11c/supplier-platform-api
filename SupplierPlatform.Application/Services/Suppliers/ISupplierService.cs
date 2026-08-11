using SupplierPlatform.Application.DTOs.Suppliers;

namespace SupplierPlatform.Application.Services.Suppliers

{
    public interface ISupplierService
    {
        Task<SupplierResponseResponse> CreateUnclaimedSupplierAsync(CreateSupplierRequest dto);
        Task<bool> ClaimSupplierProfileAsync(ClaimProfileRequest dto);
    }
}
