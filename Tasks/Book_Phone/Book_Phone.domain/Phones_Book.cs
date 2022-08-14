using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Domain
{
    public class Phones_Book
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public List<Phone_Number> Phone_Numbers { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
