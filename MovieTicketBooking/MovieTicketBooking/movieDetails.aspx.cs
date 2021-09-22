﻿using MovieTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTicketBooking
{
    public partial class movieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            MovieContext db = new MovieContext();
            Movie movie = db.Movies.FirstOrDefault(m => m.Id ==id);
            title.Controls.Add(new Literal() { Text=movie.Title});
            string html = $@"
            <div class=""container"">
                <div class=""d-flex justify-content-between align-items-center my-3"">
                    <h1>{movie.Title}</h1> 
                    <div><a runat = ""server"" href=""/bookShow.aspx?id={movie.Id}"" class=""btn btn-primary"">Book Show</a></div>
                </div>
            </div>
            <div class=""d-flex justify-content-center bg-dark container-fluid"">
                <img src = ""{movie.FullPoster}"" class=""container""/>
            </div>
            <div class=""container"">
                <h2 class=""my-3"">About The Movie</h2>
                <p>{movie.Description}</p>
                <h5 class=""my-3"">
                    <span class=""badge bg-dark"">{movie.Language}</span>
                    <span class=""badge bg-dark"">{movie.Duration}   •   {movie.Category}  •  {movie.ReleaseDate : d MMM, yyyy} </span>
                </h5>
            </div>";
            
            Details.Controls.Add(new Literal() {Text=html});
        }
    }

}