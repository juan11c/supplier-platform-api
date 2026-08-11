namespace SupplierPlatform.Application.DTOs.Suppliers

{
    public record SupplierResponseResponse(
        Guid Id,
        string BusinessName,
        string Description,
        string Phone,
        string Address,
        string Status,
        string? ClaimToken // Solo visible para el Admin al generar la invitación
    );
}
