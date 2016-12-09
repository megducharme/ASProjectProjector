using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class ProductTypeMaterial
  {
    [Key]
    public int ProductTypeMaterialId {get;set;}
    [Required]
    public int ProductTypeId {get;set;}
    [Required]
    public int MaterialId {get;set;}
    
  }
}