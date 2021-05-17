using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.tables
{
    public class Cells
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Position { get; set; }
        public string Shelf { get; set; }
        public CellType Type { get; set; }
        public int StandId { get; set; }
    }
}
