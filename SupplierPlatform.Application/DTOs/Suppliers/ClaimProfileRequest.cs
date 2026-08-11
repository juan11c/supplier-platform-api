namespace SupplierPlatform.Application.DTOs.Suppliers

{
    public record ClaimProfileRequest(
        string ClaimToken,
        string Email,
        string Password
    );
}
