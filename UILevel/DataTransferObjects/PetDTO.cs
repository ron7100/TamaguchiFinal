using System;
using System.Collections.Generic;
using System.Text;

namespace UILevel.DataTransferObjects
{
    class PetDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int PlayerId { get; set; }
        public double AnimalWeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungerLevel { get; set; }
        public int CleanLevel { get; set; }
        public int HappinessLevel { get; set; }
        public PetDTO() { }
    }
}
