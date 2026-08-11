namespace SupplierPlatform.Application.DTOs.Suppliers

{
    public record CreateSupplierRequest(
        string BusinessName,
        string Description,
        string Phone,
        string Address
    );
}
