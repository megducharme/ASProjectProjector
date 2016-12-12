using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class CountyProject
  {
    [Key]
    public int CountyProjectId {get;set;}
    [Required]
    public int ProjectTypeId {get;set;}
    [Required]
    public int EstimatedLengthInDays {get;set;}
    [Required]
    public string FamilyName {get;set;}
    [Required]
    public bool Active {get;set;}
    [Required]
    public ApplicationUser User { get; set; }
  }
}