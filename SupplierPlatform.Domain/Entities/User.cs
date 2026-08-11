using SupplierPlatform.Domain.common;
using SupplierPlatform.Domain.Enums;

namespace SupplierPlatform.Domain.Entities

{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;

        // Propiedad de navegación
        public SupplierProfile? SupplierProfile { get; set; }
    }
}
