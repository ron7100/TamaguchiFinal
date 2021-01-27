using System;
using System.Collections.Generic;
using System.Text;

namespace UILevel.DataTransferObjects
{
    class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerFamilyName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PlayerDTO() { }
    }
}
