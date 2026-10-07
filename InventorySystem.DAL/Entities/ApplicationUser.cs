using Microsoft.AspNetCore.Identity;

namespace InventorySystem.DAL.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string department { get; set; } = string.Empty;

    }
}