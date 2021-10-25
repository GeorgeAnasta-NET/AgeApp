using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.Models {
    public class Voter {

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}