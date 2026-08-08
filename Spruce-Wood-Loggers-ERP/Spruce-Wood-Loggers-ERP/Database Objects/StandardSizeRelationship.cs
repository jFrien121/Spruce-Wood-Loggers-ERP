using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP.Database_Objects
{
    class StandardSizeRelationship
    {
        public int id { get; set; } // primary key
        public int StandardNumPiecesId { get; set; } // foreign key to StandardSize
        public int CutSizeId { get; set; } // foreign key to Size
    }
}
