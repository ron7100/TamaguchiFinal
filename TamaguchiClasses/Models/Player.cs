using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaProg.Models
{
    [Table("Player")]
    public partial class Player
    {
        public Player()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("fname")]
        [StringLength(100)]
        public string Fname { get; set; }
        [Column("lname")]
        [StringLength(100)]
        public string Lname { get; set; }
        [Column("username")]
        [StringLength(100)]
        public string Username { get; set; }
        [Column("pass")]
        [StringLength(100)]
        public string Pass { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("gender")]
        [StringLength(100)]
        public string Gender { get; set; }
        [Column("birthdate", TypeName = "datetime")]
        public DateTime Birthdate { get; set; }
        [Column("activepetid")]
        public int? Activepetid { get; set; }

        [ForeignKey(nameof(Activepetid))]
        [InverseProperty(nameof(Pet.Players))]
        public virtual Pet Activepet { get; set; }
        [InverseProperty(nameof(Pet.Owner))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
