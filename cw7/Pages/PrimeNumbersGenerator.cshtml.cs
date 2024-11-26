using System.Collections;
using cw7.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.Pages;

using System.Text;

public class PrimeNumbersGenerator : PageModel
{
    public List<int>? PrimeNumbersList { get; set; }
    public void OnPost(int amount) {
        PrimeNumbersList = PrimeNumbers.GeneratePrimeList(0, amount);
        StringBuilder output = new StringBuilder("<tr>");
        for (int i = 1; i < PrimeNumbersList.Max(); i++) {
            if (PrimeNumbersList.Contains(i)) {
                output.Append($"<td class='red'>{i}</td>");
            } else {
                output.Append($"<td>{i}</td>");
            }
            if (i==PrimeNumbersList.Max()-1) {
                output.Append("</tr>");
            } else if ((i%30==0 && i!=0)) {
                output.Append("</tr><tr>");
            }
        }
        ViewData["outputTable"] = output;
    }
}