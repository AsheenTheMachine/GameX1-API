using System.ComponentModel.DataAnnotations;

namespace GameX1API.Data { }

public class AdminUser
{
    [Key]
    public int AdminUserId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

