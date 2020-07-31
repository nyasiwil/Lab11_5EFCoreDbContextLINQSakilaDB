using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab11_5EFCoreDbContextLINQSakilaDB
{
    class Film
    {
        //film_id, title, description, release_year, language_id, original_language_id, rental_duration, 
        // rental_rate, length, replacement_cost, rating, special_features, last_update

        [Key]
        public int film_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string release_year { get; set; }
        public byte language_id { get; set; }
        public byte original_language_id { get; set; }
        public byte rental_duration { get; set; }
        public decimal rental_rate { get; set; }
        public Int16 length { get; set; }
        public decimal replacement_cost { get; set; }
        public string rating { get; set; }
        public string special_features { get; set; }
        public DateTime last_update { get; set; }

        public Film(
                        /*int film_id,*/ string title, string description,
                        string release_year, /*byte language_id,*/
                        /*byte original_language_id,*/ byte rental_duration,
                        decimal rental_rate, Int16 length,
                        decimal replacement_cost, string rating
                    /*string special_features,*/ /*DateTime last_update*/
                    )
        {
            /*this.film_id = film_id;*/
            this.title = title;
            this.description = description;
            this.release_year = release_year;
            this.language_id = 1;
            this.original_language_id = 1;
            this.rental_duration = rental_duration;
            this.rental_rate = rental_rate;
            this.length = length;
            this.replacement_cost = replacement_cost;
            this.rating = rating;
            this.special_features = "Deleted Scenes";
            this.last_update = DateTime.Now;
        }

    }
}
