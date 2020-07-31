using System;
using System.Linq;

namespace Lab11_5EFCoreDbContextLINQSakilaDB
{
    class Program
    {
        #region Program Outline

        // *** Prerequisites:
        // 1 - Run the following file: 11_5_PrelabFix_SakilaDB.sql to Remove Nulls in the original_language_id field of the sakila.dbo.film table.
        // 2 - This code will also Drop a Trigger that causes issues named: [film].[insert_film]        

        // ACTUAL LAB WORK BEGINS

        // 1) CREATE A CONNECTION TO THE SAKILA DB

        // Adding EntityFramework
        // 1) In a new project, click Tools > NuGet Package Manager > Package Manager Console
        // 2) In the Package Manager Console window type: 
        // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer

        // 1) Create a new class in C#
        // 2) Add the line using Microsoft.EntityFrameworkCore
        // 3) Edit SakilaContext to inherit from DbContext
        // 4) Add the following method. This method describes how to connect to Sakila.

        // DBSet and Model Class
        // 1) Create a new class called Film table
        // 2) Add 
        //      - using Microsoft.EntityFrameworkCore;
        //      - using System.ComponentModel.dataAnnotations;
        // 3) In the Film class, create all properties that represent the 
        //      Film table 

        // Working with Data
        // * Add using System.Linq; to the top of our Program.cs class. We’ll talk about Linq next.
        // * In our Main() method, first, we need to create a new context.

        #endregion

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World from Lab11_5EFCoreDbContextLINQSakilaDB!");

            SakilaContext context = new SakilaContext();

            // Create an array of actors and set it equal to context.Film.ToArray();
            // What this does is get all of the actor records from the database and put’s them in an array.  
            // Then, loop through the array, printing the name of each film. 

            // Before Adding 3 records for 2019
            Film[] films = context.Film.ToArray();
            foreach (Film f in films)
            {

                // Print the id and title of each film.
                Console.WriteLine($"{f.film_id} {f.title}");
                //Console.WriteLine(f.film_id + " " + f.title);

            }

            // 3. Using C# only, add the following films to Sakila.
            //      add only if there are no 2019 vids EXISTS... (adjustment made to prevent dups from being added to the db table.)
            if (films.Where(f => f.release_year == "2019").ToArray().Length == 0)
            {

                Film film1 = new Film("1917", "War Drama by Director Sam Mendes", "2019", 3, Convert.ToDecimal(5.99), 179, Convert.ToDecimal(19.99), "R");
                Film film2 = new Film("Joker", "Oscar Nomimated SuperHero Drama", "2019", 3, Convert.ToDecimal(6.99), 182, Convert.ToDecimal(23.99), "R");
                Film film3 = new Film("Star Wars: The Rise of Skywalker", "Trash Disney Fanfic", "2019", 3, Convert.ToDecimal(4.99), 202, Convert.ToDecimal(19.99), "PG-13");

                context.Film.Add(film1);
                context.Film.Add(film2);
                context.Film.Add(film3);
                context.SaveChanges();

                // After Adding 3 records for 2019
                films = context.Film.ToArray();
                foreach (Film f in films)
                {

                    // Print the id, name, and description of each film.
                    Console.WriteLine($"{f.film_id} {f.title} {f.description}");
                    //Console.WriteLine(f.film_id + " " + f.title);

                }
            }

            // 4. Pull all of the data from the films table into C# into an array called allFilms.
            //      Use the ToArray() method to do this. (.ToArray() Already done above) If you get an error here, double check that
            //      the Sakila Film table doesn’t have any null values!
            Film[] allFilms = films;

            Film[] selectedFilms = allFilms.Where(f => f.release_year == "2019").ToArray();


            // Write to html file.
            HtmlPageBuilder htmlPageBuilder = new HtmlPageBuilder();
            htmlPageBuilder.CollectThenCreateHTML(selectedFilms);

        }
    }
}
