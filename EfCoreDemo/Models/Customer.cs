using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreDemo.Models
{
    public class Customer
    {
        // Ef core will automatically make the Id as Primary Key
        // its going to make it auto-increment
        public int Id { get; set; }

        // Ef core will make this field not null
        [Required]
        public string Name { get; set; }

        // Ef core will make this field not null
        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] RowVersion { get; set; }

        public ICollection<Group> Groups {get;set;}
    }
}