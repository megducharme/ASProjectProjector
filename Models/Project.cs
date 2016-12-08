using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class Project
  {
    [Key]
    public int ProjectId {get;set;}
    [Required]
    public int LengthInDays {get;set;}
    [Required]
    public string FamilyName {get;set;}
    [Required]
    public bool Active {get;set;}
    [Required]
    public int CountyId {get;set;}
  }
}