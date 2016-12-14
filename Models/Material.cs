using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class Material
  {
    [Key]
    public int MaterialId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal CostSqFt {get;set;}
    [Required]
    public decimal CountSqFt {get;set;}
  }
}