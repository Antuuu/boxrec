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
        public DateTime? DateOfBirth { get; set; }
        public int Division_ID { get; set; }
        public string Division { get => GetDivision(); }
        public string? Photo_Url { get; set; }
        [NotMapped]
        public int Wins { get; set; }
        [NotMapped]
        public int Loses { get; set; }
        [NotMapped]
        public int Draws { get; set; }
        public string? Record { get => GetRecord(); }

        // doesnt work
        private string GetDivision()
        {
            using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
            {
                string division = (from d in db.Divisions where d.ID == this.Division_ID select d.Name).FirstOrDefault();
                return division;

            }
        }

        private string GetRecord()
        {

            int w;
            int l;
            int d;

            using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
            {
                List<Fight> fights = new List<Fight>();
                fights = (from f in db.Fights where f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID select f).ToList();
                var wins = (from f in db.Fights where f.Winner_ID == this.ID select f).ToList();
                var loses = (from f in db.Fights where (f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID) && (f.Winner_ID != this.ID && f.Winner_ID != null) select f).ToList();
                var draws = (from f in db.Fights where (f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID) && f.Winner_ID == null select f).ToList();
                w = wins.Count();
                l = loses.Count();
                d = loses.Count();
            }

            string record = $"{w}-{d}-{l}";


            return record;
        }


    }



}
