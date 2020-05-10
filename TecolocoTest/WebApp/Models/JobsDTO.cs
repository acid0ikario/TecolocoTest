using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class JobsDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Display(Name = "Create At")]
        public System.DateTime CreatedAt { get; set; }
        [Display(Name = "Expire At")]
        public System.DateTime ExpiredAt { get; set; }

        public string strCreatedAt
        {
            get { return CreatedAt.ToShortDateString(); }
        }
        public string strExpiredAt
        {
            get { return ExpiredAt.ToShortDateString(); }
        }

    }
}
