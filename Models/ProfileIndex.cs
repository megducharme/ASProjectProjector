using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASProjectProjector.Models
{
  public class ProfileIndex
  {
    public string ProjectType {get;set;}
    public decimal LengthInDays {get;set;}
    public string FamilyName {get;set;} 
    public string CodeName {get;set;}
  }
}