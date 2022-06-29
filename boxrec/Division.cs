using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxrec
{
    /// <summary>
    /// Class <c>Division</c> models weight Division boxer.
    /// </summary>
    /// 
    public class Division
    {
        /// <summary>
        /// int <c>ID</c> referts to Division ID in database.
        /// </summary>
        /// 
        public int ID { get; set; }
        /// <summary>
        /// string <c>Name</c> referts to name of the Division of particular ID in database.
        /// </summary>
        public string? Name { get; set; }

    }
}
