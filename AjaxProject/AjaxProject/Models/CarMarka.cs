using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxProject.Models
{
    public class CarMarka
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarModel> Models { get; set; }
    }
}