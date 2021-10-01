using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance.Entities
{
    class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get { return string.Format("{0} {1}", Lastname, Firstname); }
        }

    }
}
