using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics.Models
{
    public class Polyline 
    {
        private List<Vector3> vertices = new List<Vector3>();
        public Polyline(IList<Vector3> v, bool closed = false)
        {
            vertices.AddRange(v);
            if (closed)
                vertices.Add(v[0]);
        }
        public List<Vector3> Vertices
        {
            get { return vertices; }
        }
    }
}
