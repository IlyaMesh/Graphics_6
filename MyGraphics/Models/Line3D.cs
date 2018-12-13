using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics.Models
{
    public class Line3D : IModel
    {
        Vector3 v1, v2;
        public Vector3 Pos { get; set; }
        public Line3D(Vector3 a, Vector3 b)
        {
            v1 = a;
            v2 = b;
        }
        public List<Polyline> GetLines()
        {
            return new List<Polyline>() { new Polyline(new List<Vector3>() { v1, v2})
            };
        }
        public List<Polygon> GetPolygons()
        {
            return new List<Polygon>();
        }
    }
}
