//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class VehicleModel
    {
        public int Id { get; set; }
        [Required]
        public int MakeId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string ModelAbbreviation { get; set; }
    
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
