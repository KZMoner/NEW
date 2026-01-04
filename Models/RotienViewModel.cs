using System.ComponentModel.DataAnnotations;

namespace New.Models;

public class RotienViewModel
{
    public rotien NewRotien { get; set; } = new rotien();  // For form
    public List<rotien> RotienList { get; set; } =new List<rotien> (); // For table
}
