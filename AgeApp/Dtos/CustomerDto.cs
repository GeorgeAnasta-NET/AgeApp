using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeApp.Dtos {
    public class CustomerDto {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}