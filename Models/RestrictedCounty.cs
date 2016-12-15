using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class RestrictedCounty
  {
    [Key]
    public int RestrictedCountyId {get;set;}
    [Required]
    public string GroupDonating {get;set;}
    public string ContactPerson {get;set;}
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Amount {get;set;}
    [Required]
    public ApplicationUser User { get; set; }
  }
}