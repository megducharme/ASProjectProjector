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
    [Required]
    public double Amount {get;set;}
  }
}