using System;

namespace cw12_ef.Models;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public double Price { get; set; }
}
