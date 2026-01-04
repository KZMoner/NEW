using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models;

public class Registration
{

    [Key]
     public int ID { get; set; }


    [Required(ErrorMessage = "Enter your data")]
    [DataType(DataType.Text)]
    public string Name { get; set; }


    
    [Required(ErrorMessage = "Enter your data")]
    [DataType(DataType.Text)]
    public string FatherName { get; set; }


    [Required(ErrorMessage = "Enter your data")]
    [DataType(DataType.Text)]
    public string Department{ get; set; }


    [Required(ErrorMessage = "Enter your data")]
    [DataType(DataType.Text)]
    public string Username{ get; set; }


    [Required(ErrorMessage = "Enter your data")]
    [DataType(DataType.EmailAddress)]
    public string Gmail{ get; set; }


    [Required(ErrorMessage = "Enter your data")]
    [DataType(dataType:DataType.Password)]
    public  string Password{ get; set; }
  
  [NotMapped] // This field is not saved to DB
    public string ConfirmPassword { get; set; }


    


}