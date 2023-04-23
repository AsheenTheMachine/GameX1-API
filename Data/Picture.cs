using System.ComponentModel.DataAnnotations;

namespace GameX1API.Data { }

public class Picture
{
    [Key]
    public int PictureId { get; set; }

    [Required]
    public string Url{ get; set; }
}

