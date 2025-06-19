using System.ComponentModel.DataAnnotations;

namespace Project2144.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}