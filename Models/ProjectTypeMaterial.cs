using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class ProjectTypeMaterial
  {
    [Key]
    public int ProjectTypeMaterialId {get;set;}
    [Required]
    public int ProjectTypeId {get;set;}
    [Required]
    public int MaterialId {get;set;}
    
  }
}