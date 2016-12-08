using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class Budget
  {
    [Key]
    public int BudgetId {get;set;}
    [Required]
    public int CountyId {get;set;}
    [Required]
    public double Total {get;set;}
  }
}