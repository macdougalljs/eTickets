﻿using eTickets.Data.Base;
using eTickets.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {

       
        [Display(Name ="Movie name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description
        {
            get; set;
        }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price
        {
            get; set;
        }
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL
        {
            get; set;
        }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate
        {
            get; set;
        }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate
        {
            get; set;
        }

        // need to add Enum

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory
        {
            get; set;
        }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actors are required")]
        public List<int> ActorIds
        {
            get; set;
        }

        [Display(Name = "Select cinema(s)")]
        [Required(ErrorMessage = "Movie cinemas are required")]
        public int CinemaId
        {
            get; set;
        }

        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Movie producer required")]
        public int ProducerId
        {
            get; set;
        }
      

    }
}
