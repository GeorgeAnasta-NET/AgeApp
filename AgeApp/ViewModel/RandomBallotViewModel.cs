using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.ViewModel {
    public class RandomBallotViewModel {

        public Ballot Ballot { get; set; }
        public List<Voter> Voters { get; set; }

    }
}