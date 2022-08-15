using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Domain
{
    public class Phone_Number
    {
        public Guid Id { get; set; }
        [Required]
        public string Number { get; set; }

        public Guid Phones_BookId { get; set; }
        public Phones_Book Phones_Book { get; set; }
    }
}
