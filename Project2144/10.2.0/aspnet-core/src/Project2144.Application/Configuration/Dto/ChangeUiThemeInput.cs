﻿using System.ComponentModel.DataAnnotations;

namespace Project2144.Configuration.Dto;

public class ChangeUiThemeInput
{
    [Required]
    [StringLength(32)]
    public string Theme { get; set; }
}
