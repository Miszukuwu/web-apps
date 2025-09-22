using System;
using System.ComponentModel.DataAnnotations;

namespace cw12_ef.Models;

public class Game
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Publisher { get; set; }
    [Required]
    public double Price { get; set; }
}
