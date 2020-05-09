using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
   public class Jobs
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ExpiredAt { get; set; }
    }
}
