using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MyGraphics.Models;
using LibraryForThisTask;

namespace MyGraphics
{
    public class Scene
    {
        public List<IModel> Models { get; set; }
        public Scene()
        {
            Models = new List<IModel>();
        }
        public Bitmap DrawAll(Camera cam, Screen scr)
        {
            Bitmap bmp = new Bitmap(scr.Size.Width, scr.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            //process of drawing
            List<Polyline> lines = new List<Polyline>();

            List<Polygon> polygons = new List<Polygon>();
            foreach (IModel m in Models)
                foreach (Polygon p1 in m.GetPolygons())
                {
                    List<Vector3> v1 = new List<Vector3>();
                    foreach (Vector3 v in p1.Vecties)
                        v1.Add(cam.Convert(v));
                    polygons.Add(new Polygon(v1));
                }
            foreach (var p in polygons)
            {
                List<Point> points = new List<Point>();
                foreach (Vector3 v in p.Vecties)
                    points.Add(scr.Convert(v));
                Random rnd = new Random();
                Brush mydbrush = new SolidBrush(Color.FromArgb((120), (0), (0), (0)));
                g.FillPolygon(mydbrush, points.ToArray());
            }

            foreach (IModel m in Models)
                foreach (Polyline pl in m.GetLines()) // поворот всех точек в систему координат камеры
                {
                    List<Vector3> vl = new List<Vector3>();
                    foreach (Vector3 v in pl.Vertices)
                        vl.Add(cam.Convert(v));
                    lines.Add(new Polyline(vl));
                }
            
            foreach (var pl in lines)
            {
                List<Point> points = new List<Point>();
                foreach (Vector3 v in pl.Vertices)
                    points.Add(scr.Convert(v));
                g.DrawLines(Pens.Black, points.ToArray());
            }
            g.Dispose();
            return bmp;
        }
    }
}
