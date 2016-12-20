using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASProjectProjector.Models
{
  public class AdditionalCost
  {
    [Key]
    public int AdditionalCostId {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Amount {get;set;}
    [Required]
    public int CountyProjectId {get;set;}
    public CountyProject CountyProject { get; set; }
    public ApplicationUser User { get; set; }
  }
}