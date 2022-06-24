using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
     
    public class Boxer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Division_ID { get; set; }
        public string? Photo_Url { get; set; }
        [NotMapped]
        public int Wins { get; set; }
        [NotMapped]
        public int Loses { get; set; }
        [NotMapped]
        public int Draws { get; set; }

        public string GetDivision()
        {
            return "siema";
        }
    }



}
