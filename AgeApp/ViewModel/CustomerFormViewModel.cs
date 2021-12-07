using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.ViewModel {
    public class CustomerFormViewModel {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Voter Voter { get; set; }
    }
}