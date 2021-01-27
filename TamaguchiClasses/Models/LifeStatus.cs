using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiClasses.Models
{
    [Table("LifeStatus")]
    public partial class LifeStatus
    {
        public LifeStatus()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("lifestatusid")]
        public int Lifestatusid { get; set; }
        [Required]
        [Column("lifestatusname")]
        [StringLength(100)]
        public string Lifestatusname { get; set; }

        [InverseProperty(nameof(Pet.Lifestatus))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
