using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    /// <summary>
    /// Class <c>Boxer</c> models boxer person.
    /// </summary>
    /// 
    public class Boxer
    {

        /// <summary>
        /// int <c>ID</c> referts to Boxer ID in database.
        /// </summary>
        /// 
        public int ID { get; set; }
        /// <summary>
        /// string <c>Name</c> referts to Boxer Name in database.
        /// </summary>
        /// 
        public string? Name { get; set; }
        /// <summary>
        /// string <c>Surname</c> referts to Boxer Surname in database.
        /// </summary>
        /// 
        public string? Surname { get; set; }
        /// <summary>
        /// DateTime <c>DateOfBirth</c> referts to Boxer DateOfBirth in database.
        /// </summary>
        /// 
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// int <c>Division_ID</c> referts to Boxer Division_ID in database.
        /// </summary>
        /// 
        public int Division_ID { get; set; }
        /// <summary>
        /// string <c>Division</c> get Division name based on public int Division_ID to fetch name of the division.
        /// </summary>
        /// 
        public string Division { get => GetDivision(); }
        /// <summary>
        /// string <c>Photo_Url</c> referts to Boxer Photo_Url in database.
        /// </summary>
        /// 
        public string? Photo_Url { get; set; }
        /// <summary>
        /// int <c>Wins</c> not mapped property used to calculat Wins of particulat boxer in FetchFight() method. 
        /// </summary>
        /// 
        [NotMapped]
        public int Wins { get; set; }
        /// <summary>
        /// int <c>Loses</c> not mapped property used to calculat Loses of particulat boxer in FetchFight() method. 
        /// </summary>
        /// 
        [NotMapped]
        public int Loses { get; set; }
        /// <summary>
        /// int <c>Draws</c> not mapped property used to calculat Draws of particulat boxer in FetchFight() method. 
        /// </summary>
        /// 
        [NotMapped]
        public int Draws { get; set; }
        /// <summary>
        /// string <c>Record</c> not mapped property used generate string with record of boxer with GetRecord() method.
        /// </summary>
        /// 
        public string? Record { get => GetRecord(); }




        private string GetDivision()
        {
            using (var db = new BoxrecContext())
            {
                string? division = (from d in db.Divisions where d.ID == this.Division_ID select d.Name).FirstOrDefault();
                return division;

            }
        }

        private string GetRecord()
        {
            int w;
            int l;
            int d;

            using (var db = new BoxrecContext())
            {
                var fights = (from f in db.Fights where f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID select f).ToList();
                var wins = (from f in db.Fights where f.Winner_ID == this.ID select f).ToList();
                var loses = (from f in db.Fights where (f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID) && (f.Winner_ID != this.ID && f.Winner_ID != null) select f).ToList();
                var draws = (from f in db.Fights where (f.Boxer1_ID == this.ID || f.Boxer2_ID == this.ID) && f.Winner_ID == 0 select f).ToList();
                w = wins.Count;
                l = loses.Count;
                d = draws.Count;
            }
            string record = $"{w}-{d}-{l}";
            return record;
        }


    }



}
