using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxProject.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarMarkaID { get; set; }

        public CarMarka CarMarka { get; set; }
    }
}