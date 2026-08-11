namespace SupplierPlatform.Domain.Enums

{
    public enum ProfileStatus
    {
        Unclaimed = 1, // Creado por el Admin, pendiente de ser reclamado por el proveedor
        Active = 2,    // Reclamado y en funcionamiento
        Suspended = 3  // Desactivado por incumplimiento
    }
}
