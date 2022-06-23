using System;
using System.Collections.Generic;
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
        public int Division { get; set; }
        public string Record { get => GetRecord(); }

        public string GetRecord()
        {
            return "siema";
        }
        public string GetDivision()
        {
            return "siema";
        }
    }



}
