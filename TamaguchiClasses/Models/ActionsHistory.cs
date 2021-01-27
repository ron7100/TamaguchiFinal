using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaProg.Models
{
    [Table("ActionsHistory")]
    public partial class ActionsHistory
    {
        [Key]
        [Column("ActionHistoryID")]
        public int ActionHistoryId { get; set; }
        [Column("PetID")]
        public int? PetId { get; set; }
        [Column("lifeSpanID")]
        public int? LifeSpanId { get; set; }
        [Column("ActionID")]
        public int? ActionId { get; set; }

        [ForeignKey(nameof(ActionId))]
        [InverseProperty(nameof(ActionInfo.ActionsHistories))]
        public virtual ActionInfo Action { get; set; }
        [ForeignKey(nameof(LifeSpanId))]
        [InverseProperty("ActionsHistories")]
        public virtual LifeSpan LifeSpan { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty("ActionsHistories")]
        public virtual Pet Pet { get; set; }
    }
}
