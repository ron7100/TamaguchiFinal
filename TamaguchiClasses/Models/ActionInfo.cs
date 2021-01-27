using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiClasses.Models
{
    [Table("ActionInfo")]
    public partial class ActionInfo
    {
        public ActionInfo()
        {
            ActionsHistories = new HashSet<ActionsHistory>();
        }

        [Key]
        [Column("actioninfoid")]
        public int Actioninfoid { get; set; }
        [Required]
        [Column("actioninfoname")]
        [StringLength(100)]
        public string Actioninfoname { get; set; }
        [Column("hungereffect")]
        public int Hungereffect { get; set; }
        [Column("cleannesseffect")]
        public int Cleannesseffect { get; set; }
        [Column("happinesseffect")]
        public int Happinesseffect { get; set; }
        [Column("weighteffect")]
        public int? Weighteffect { get; set; }

        [InverseProperty(nameof(ActionsHistory.Action))]
        public virtual ICollection<ActionsHistory> ActionsHistories { get; set; }
    }
}
