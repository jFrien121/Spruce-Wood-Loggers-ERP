using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP.Database_Objects
{
    class CutSize
    {
        public int id { get; set; } // primary key
        public double thickness { get; set; }
        public double width { get; set; }
    }
}
