using System.ComponentModel.DataAnnotations;

namespace New.Models;

public class rotien
{
    internal rotien NewRotien;

    // id decleration
    [Key]
     public int ID { get; set; }

    //Data Decleration
    [Required(ErrorMessage = "Enter your data")]
    public DateTime Date { get; set; }


    // Work decleration
    [Required(ErrorMessage = "work is importen")]
    [StringLength(100, ErrorMessage = "out of lenght")]
    public  string Work { get; set; }= string.Empty;


    //  Place decleration 
    [Required(ErrorMessage = "is required")]
    [StringLength(100, ErrorMessage = "out of lenght")]
    [DataType(DataType.Text)]
    public string place { get; set; } = string.Empty;


}