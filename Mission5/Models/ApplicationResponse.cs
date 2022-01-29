using System;
using System.ComponentModel.DataAnnotations;

namespace Mission5.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required(ErrorMessage ="MovieID is required")]
        public int MovieId { get; set; }

        public int Categoryid { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [MaxLength(4)]
        public string Year { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Note { get; set; }
    }
}
