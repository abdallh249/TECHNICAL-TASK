
using System.ComponentModel.DataAnnotations;

public class User
{
     [Key]
    public int ID  {get;set;}
    [Required] 
    public string FullName {get;set;} = string.Empty ;
    [Required] 
    public string Email {get;set;} = string.Empty ;
    [Required] 
    public string Password {get;set;} = string.Empty ;
    
      public String  role {get;set;} ="User";

}