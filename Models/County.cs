using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class County
  {
    [Key]
    public int CountyId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public double AdditionalCostsId {get;set;}
    [Required]
    public double HomesFigure {get;set;}
    [Required]
    public int TotalWorkCrews {get;set;}
  }
}