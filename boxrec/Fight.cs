using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string? FightResult { get; set; }
        [NotMapped]
        public int? FightNumber { get; set; }
        [NotMapped]
        public string? Opponent { get; set; }

        public string GetBoxerRecord()
        {
            return "siema";
        }

    }
}
