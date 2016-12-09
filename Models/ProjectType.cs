using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class ProjectType
  {
    [Key]
    public int ProjectTypeId {get;set;}
    [Required]
    public string Name {get;set;}
    public ICollection<Material> Materials {get;set;}
  }
}