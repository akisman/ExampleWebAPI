using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Foreign Key
        public int PetOwnerId { get; set; }
        // Navigation property
        //public PetOwner PetOwner { get; set; }

        // Foreign Key
        public int? PetWalkerId { get; set; }
        //public PetWalker PetWalker { get; set; }
    }
}
