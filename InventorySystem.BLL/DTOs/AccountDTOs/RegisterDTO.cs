using System.ComponentModel.DataAnnotations;

namespace InventorySystem.BLL.DTOs.AccountDTOs
{
    public class RegisterDTO
    {
        [Required] public string UserName { get; set; } = string.Empty;
        [Required][MinLength(8)] public string Password { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Phone { get; set; } = string.Empty;
        [Required] public string department { get; set; } = string.Empty;
    }
}