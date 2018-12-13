using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics.Models
{
    public interface IModel
    {
        Vector3 Pos{ get; set; }
        List<Polyline> GetLines();
        List<Polygon> GetPolygons();
    }
}

