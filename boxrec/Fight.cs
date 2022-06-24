using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    public class Fight
    {
        public int ID { get; set; }
        public DateTime DateOfFight{ get; set; }
        public int? Belt_ID { get; set; }
        public int Boxer1_ID { get; set; }
        public int Boxer2_ID { get; set; }
        public int? Winner_ID { get; set; }


        public string GetBoxerRecord()
        {
            return "siema";
        }

    }
}
