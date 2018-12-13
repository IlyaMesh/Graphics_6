using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics.Models
{
    public class Polygon
    {
        private List<Vector3> vectices = new List<Vector3>();

        public Polygon(IList<Vector3> v)
        {
            vectices.AddRange(v);
        }

        public List<Vector3> Vecties { get { return vectices; } }
    }
}
