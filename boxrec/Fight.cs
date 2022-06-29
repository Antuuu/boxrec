﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    /// <summary>
    /// Class <c>Fight</c> models Fight of two boxers
    /// </summary>
    /// 
    public class Fight
    {
        /// <summary>
        /// int <c>ID</c> referts to Fight ID in database
        /// </summary>
        /// 
        public int ID { get; set; }
        /// <summary>
        /// DateTime <c>DateOfFight</c> referts to the date of the Fight
        /// </summary>
        /// 
        public DateTime? DateOfFight{ get; set; }
        /// <summary>
        /// int <c>Boxer1_ID</c> referts to the ID of first boxer who participated in fight
        /// </summary>
        /// 
        public int Boxer1_ID { get; set; }
        /// <summary>
        /// string <c>Boxer1</c> fetch name and surname using <c>GetBoxer1</c> method based on ID of Boxer
        /// </summary>
        /// 
        public string Boxer1 { get => GetBoxer1(); }
        /// <summary>
        /// int <c>Boxer2_ID</c> referts to the ID of first boxer who participated in fight
        /// </summary>
        /// 
        public int Boxer2_ID { get; set; }
        /// <summary>
        /// string <c>Boxer2</c> fetch name and surname using <c>GetBoxer2</c> method based on ID of Boxer
        /// </summary>
        /// 
        public string Boxer2 { get => GetBoxer2(); }
        /// <summary>
        /// string <c>Winner</c> fetch name and surname using <c>GetWinner</c> method based on ID of Winner
        /// </summary>
        /// 
        public string? Winner { get => GetWinner(); }
        /// <summary>
        /// int <c>Winner_ID</c> referts to the ID of boxer who won the fight.
        /// </summary>
        /// 
        public int? Winner_ID { get; set; }
        /// <summary>
        /// string <c>FightResult</c> is not mapped to database table, this property is used to get information if particular boxer is Winner or Loser of fight, used in BoxerDetailsWindow.
        /// </summary>
        /// 
        [NotMapped]
        public string? FightResult { get; set; }
        /// <summary>
        /// int <c>FightNumber</c> is not mapped to database table, this property is used to generate number of fights of particular Boxer,  used in BoxerDetailsWindow.
        /// </summary>
        /// 
        [NotMapped]
        public int? FightNumber { get; set; }
        /// <summary>
        /// string <c>Opponent</c> is not mapped to database table, this property is used to fetch name and surname of Oppnent of particulat Boxer.,  used in BoxerDetailsWindow.
        /// </summary>
        /// 
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

        // We doubled code hare, maybe we should use one method GetBoxer which use BoxerID parameter?
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
