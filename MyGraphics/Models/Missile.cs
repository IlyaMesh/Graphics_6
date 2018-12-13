using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics.Models
{
    public class Missile : IModel
    {
        public float Velocity { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float Angle { get; set; }
        public Vector3 Pos { get; set; }//top left far

        public Vector3 TC { get; set; }
        //public Vector3 DC { get; set; }
        public float A { get; private set; }
        public float B { get; private set; }
        public Missile(Vector3 pos, Vector3 dc, float width, float height)
        {
            //DC = dc;
            Pos = pos;
            dc = new Vector3(0, 0, 30);
            TC=pos;
            A = width / 2;
            B = height / 2;
            Angle = (float)Math.PI/2.1f;
            Velocity = 60;
            //VelocityX = Velocity*(float)Math.Cos(Angle);
        }

        private static List<Vector3> EllipsePoints(float a, float b, int n, Vector3 center)
        {
            
            List<Vector3> points = new List<Vector3>();
            float x, y;
            for (int i = 1; i <= n; i++)
            {
                x = (float)(a * Math.Cos(2 * i * Math.PI / n)) + center.X;
                y = (float)(b * Math.Sin(2 * i * Math.PI / n)) + center.Y;

                points.Add(new Vector3(x, y, center.Z));
            }

            return points;
        }

        public List<Polyline> GetLines()
        {
            TC = Pos;
            Vector3 DC = Pos + new Vector3(0, 0, 30);
            List <Polyline> r = new List<Polyline>();
            List<Vector3> TopEllipse = EllipsePoints(A, B, 30, TC);
            List<Vector3> DownEllipse = EllipsePoints(A, B, 30, DC);
            r.Add(new Polyline(TopEllipse, true));
            r.Add(new Polyline(DownEllipse, true));
            for (int i = 0; i < TopEllipse.Count - 1; i++)
            {
                r.Add(new Polyline(new List<Vector3>() { TopEllipse[i], TopEllipse[i + 1], DownEllipse[i + 1], DownEllipse[i] }, true));
            }
            return r;
        }

        public List<Polygon> GetPolygons()
        {
            TC = Pos;
            Vector3 DC = Pos + new Vector3(0, 0, 30);
            List<Polygon> list = new List<Polygon>();
            List<Vector3> TopEllipse = EllipsePoints(A, B, 30, TC);
            List<Vector3> DownEllipse = EllipsePoints(A, B, 30, DC);
            for (int i = 0; i < TopEllipse.Count - 1; i++)
            {
                list.Add(new Polygon(new List<Vector3>() { TopEllipse[i], TopEllipse[i + 1], TC }));
                list.Add(new Polygon(new List<Vector3>() { DownEllipse[i], DownEllipse[i + 1], DC }));
                list.Add(new Polygon(new List<Vector3>() { TopEllipse[i], TopEllipse[i + 1], DownEllipse[i + 1], DownEllipse[i] }));
            }

            list.Add(new Polygon(new List<Vector3>() { TopEllipse[0], TopEllipse[TopEllipse.Count - 1],TC }));
            list.Add(new Polygon(new List<Vector3>() { DownEllipse[0], DownEllipse[DownEllipse.Count - 1], DC }));
            list.Add(new Polygon(new List<Vector3>() { TopEllipse[0], TopEllipse[TopEllipse.Count - 1], DownEllipse[DownEllipse.Count - 1], DownEllipse[0] }));
            return list;
        }
    }
}
