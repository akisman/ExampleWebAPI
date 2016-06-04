using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Core.Domain
{
    public class PetOwner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<PetWalker> PetWalkers { get; set; }
    }
}
