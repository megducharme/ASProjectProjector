using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public ProjectType ProjectType {get;set;}
    [Required]
    [DisplayName("Code Name")]
    public string CodeName {get;set;}
    [Required]
    [DisplayFormat(DataFormatString="{0:#.####}")]
    [DisplayName("Estimated Length In Days")]
    public decimal EstimatedLengthInDays {get;set;}
    [Required]
    [DisplayName("Family Name")]
    public string FamilyName {get;set;}
    [Required]
    public bool Active {get;set;}
    [Required]
    public ApplicationUser User { get; set; }
    [Required]
    [DisplayFormat(DataFormatString="{0:#.####}")]
    [DisplayName("Project Square Footage")]
    public decimal ProjectSqFt {get;set;}
    [DisplayName("Total Project Cost")]
    public decimal TotalProjectCost {get;set;}
    public virtual ICollection<AdditionalCost> AdditionalCosts {get;set;}
  }
}