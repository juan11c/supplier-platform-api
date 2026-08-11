using System.Security.Cryptography;
using SupplierPlatform.Application.Interfaces;

namespace SupplierPlatform.Infrastructure.Services;

public class ClaimTokenGenerator : IClaimTokenGenerator
{
    public string GenerateToken()
    {
        var randomBytes = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToHexString(randomBytes).ToLowerInvariant();
    }
}