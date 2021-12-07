using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.ViewModel {
    public class BallotFormViewModel {
        public IEnumerable<Genre> Genres { get; set; }
        public Ballot Ballot { get; set; }
        public string Title {
            get {
                if (Ballot != null && Ballot.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}