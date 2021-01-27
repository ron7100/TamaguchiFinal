using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaProg.Models
{
    [Table("lifeSpan")]
    public partial class LifeSpan
    {
        public LifeSpan()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("lifeSpanID")]
        public int LifeSpanId { get; set; }
        [Required]
        [Column("lifeSpanName")]
        [StringLength(100)]
        public string LifeSpanName { get; set; }
        public int Duration { get; set; }

        [InverseProperty(nameof(ActionsHistory.LifeSpan))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
        [InverseProperty(nameof(Pet.Lifespan))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
