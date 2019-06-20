using AjaxProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxProject.DAL
{
    public class CarContext : DbContext
    {
        public CarContext() : base ("CarDBCS")
        {
        }

        public DbSet<CarMarka> CarMarkas { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

    }
}