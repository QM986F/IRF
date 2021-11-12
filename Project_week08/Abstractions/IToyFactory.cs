using Project_week08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_week08.Abstractions
{
    public interface IToyFactory
    {
        Toy CreateNew();
    }
}
