using Microsoft.AspNetCore.Mvc;
using SupplierPlatform.Application.DTOs.Suppliers;
using SupplierPlatform.Application.Services.Suppliers;

namespace SupplierPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request)
    {
        var response = await _supplierService.CreateUnclaimedSupplierAsync(request);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
    }

    [HttpPost("claim")]
    public async Task<IActionResult> Claim([FromBody] ClaimProfileRequest request)
    {
        var success = await _supplierService.ClaimSupplierProfileAsync(request);

        if (!success)
        {
            return BadRequest(new { message = "El token de invitación es inválido o ha expirado." });
        }

        return Ok(new { message = "Perfil de proveedor reclamado exitosamente." });
    }
}