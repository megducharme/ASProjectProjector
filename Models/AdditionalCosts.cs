using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASProjectProjector.Models
{
  public class AdditionalCosts
  {
    [Key]
    public int AdditionalCostsId {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    public double Amount {get;set;}
  }
}