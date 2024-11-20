using System.Collections;
using cw7.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.Pages;

public class PrimeNumbersGenerator : PageModel
{
    public List<int>? PrimeNumbersList { get; set; }
    public void OnPost(int amount) {
        PrimeNumbersList = PrimeNumbers.GeneratePrime(amount);
    }
}