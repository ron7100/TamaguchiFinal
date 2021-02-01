using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiClasses.Models;

namespace TamaguchiFinale.DataTransferObjects
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerFamilyName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PlayerDTO(Player p) 
        {
            this.PlayerId = p.Id;
            this.PlayerName = p.Fname;
            this.PlayerFamilyName = p.Lname;
            this.Email = p.Email;
            this.BirthDate = p.Birthdate;
        }
    }
}
