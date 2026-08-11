using SupplierPlatform.Domain.common;
using SupplierPlatform.Domain.Enums;

namespace SupplierPlatform.Domain.Entities
{
    public class SupplierProfile : BaseEntity
    {
        public string BusinessName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ProfileStatus Status { get; set; } = ProfileStatus.Unclaimed;

        // Campos para el flujo de reclamación de perfil (Claim Profile)
        public string? ClaimToken { get; set; }
        public DateTime? ClaimTokenExpiresAt { get; set; }

        // Relación con el Usuario (Opcional/Nullable hasta que el proveedor reclame la cuenta)
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        // Colecciones de navegación

        // public ICollection<Product> Products { get; set; } = new List<Product>();

        // public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
