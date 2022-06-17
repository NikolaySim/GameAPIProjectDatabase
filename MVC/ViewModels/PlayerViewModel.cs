using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string City { get; set; }
       

        public PlayerViewModel() { }

        public PlayerViewModel(PlayerDTO playerDto)
        {
            Id = playerDto.Id;
            FirstName = playerDto.FirstName;
            LastName = playerDto.LastName;
            DOB = playerDto.DOB;
            City = playerDto.City;
        }
    }
}