using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeApp.ViewModel {
    public class BallotFormViewModel {

        public IEnumerable<Genre> Genres { get; set; }
        public Ballot Ballot { get; set; }

        public long? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title {
            get {
                return Id != 0 ? "Edit Ballot" : "New Ballot";
            }
        }

        public BallotFormViewModel()
        {
            Id = 0;
        }

        public BallotFormViewModel(Ballot ballot)
        {
            Id = ballot.Id;
            Name = ballot.Name;
            ReleaseDate = ballot.ReleaseDate;
            NumberInStock = ballot.NumberInStock;
            GenreId = ballot.GenreId;
        }
    }
}