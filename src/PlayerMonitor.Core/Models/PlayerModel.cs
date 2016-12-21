using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerMonitor.Core
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public ICollection<SessionModel> Sessions { get; set; }
    }
}
