using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string Size { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }



        public GameViewModel() { }

        public GameViewModel(GameDTO gameDto)
        {
            Id = gameDto.Id;
            Title = gameDto.Title;
            Details = gameDto.Details;
            Genre = gameDto.Genre;
            ReleaseDate = gameDto.ReleaseDate;
            Size = gameDto.Size;
            Platform = gameDto.Platform;
            Publisher = gameDto.Publisher;
        }
    }
}