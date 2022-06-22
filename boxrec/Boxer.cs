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
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dateofbirth { get; set; }
        public int division { get; set; }
        public string record { get => GetRecord(); }

        public string GetRecord()
        {
            return "siema";
        }
    }



}
