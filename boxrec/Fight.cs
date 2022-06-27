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
        public DateTime? DateOfFight{ get; set; }
        public int? Belt_ID { get; set; }
        public int Boxer1_ID { get; set; }
        public string Boxer1 { get => GetBoxer1(); }
        public int Boxer2_ID { get; set; }
        public string Boxer2 { get => GetBoxer2(); }
        public string? Winner { get => GetWinner(); }
        public int? Winner_ID { get; set; }
        [NotMapped]
        public string? FightResult { get; set; }
        [NotMapped]
        public int? FightNumber { get; set; }
        [NotMapped]
        public string? Opponent { get; set; }

        private string GetWinner()
        {
            if (Winner_ID != 0)
            {
                using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
                {
                    string? winnerName = (from b in db.Boxers where b.ID == this.Winner_ID select b.Name).FirstOrDefault();
                    string? winnerSurname = (from b in db.Boxers where b.ID == this.Winner_ID select b.Surname).FirstOrDefault();
                    return $"{winnerName} {winnerSurname}";
                }
            }
            else return "Draw";
        }

        private string GetBoxer1()
        {
            using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
            {
                string? boxer1Name = (from b in db.Boxers where b.ID == this.Boxer1_ID select b.Name).FirstOrDefault();
                string? boxer1Surname = (from b in db.Boxers where b.ID == this.Boxer1_ID select b.Surname).FirstOrDefault();
                return $"{boxer1Name} {boxer1Surname}";
            }
        }

        private string GetBoxer2()
        {
            using (BoxrecContext db = new BoxrecContext(@"Data Source=localhost;Initial Catalog=boxrec;Integrated Security=True"))
            {
                string? boxer2Name = (from b in db.Boxers where b.ID == this.Boxer2_ID select b.Name).FirstOrDefault();
                string? boxer2Surname = (from b in db.Boxers where b.ID == this.Boxer2_ID select b.Surname).FirstOrDefault();
                return $"{boxer2Name} {boxer2Surname}";
            }
        }

    }
}
