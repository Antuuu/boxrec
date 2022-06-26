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
            string div;
            using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
            {
                List<Division> divs = new List<Division>();

                divs = (from d in db.Divisions select d).ToList();
                var divis = from d in divs
                      where d.ID == this.Division_ID
                      select d.Name.ToString();

                div = divis.ToString();

            }
            
            return div;
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
