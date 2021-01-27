using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaProg.Models
{
    [Table("PET")]
    public partial class Pet
    {
        public Pet()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("petname")]
        [StringLength(100)]
        public string Petname { get; set; }
        [Column("ownerid")]
        public int? Ownerid { get; set; }
        [Column("petbirthdate", TypeName = "datetime")]
        public DateTime Petbirthdate { get; set; }
        [Column("petweight")]
        public int Petweight { get; set; }
        [Column("hungerlevel")]
        public int Hungerlevel { get; set; }
        [Column("cleanlevel")]
        public int Cleanlevel { get; set; }
        [Column("happinesslevel")]
        public int Happinesslevel { get; set; }
        [Column("lifestatusid")]
        public int Lifestatusid { get; set; }
        [Column("lifespanid")]
        public int Lifespanid { get; set; }

        [ForeignKey(nameof(Lifespanid))]
        [InverseProperty(nameof(LifeSpan.Pets))]
        public virtual LifeSpan Lifespan { get; set; }
        [ForeignKey(nameof(Lifestatusid))]
        [InverseProperty(nameof(LifeStatus.Pets))]
        public virtual LifeStatus Lifestatus { get; set; }
        [ForeignKey(nameof(Ownerid))]
        [InverseProperty(nameof(Player.Pets))]
        public virtual Player Owner { get; set; }
        [InverseProperty(nameof(ActionsHistory.Pet))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
        [InverseProperty(nameof(Player.Activepet))]
        public virtual ICollection<Player> Players { get; set; }
    }
}
