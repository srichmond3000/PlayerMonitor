using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets/ sets the duration of the session in min.
        /// </summary>
        public int Duration { get; set; }

        public int PlayerId { get; set; }
        public PlayerModel Player { get; set; }
    }
}
