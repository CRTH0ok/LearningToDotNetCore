using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public Boolean? WillAttend { get; set; }
    }
}
