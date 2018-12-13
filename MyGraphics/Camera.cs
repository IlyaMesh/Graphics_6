using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForThisTask;

namespace MyGraphics
{
    public class Camera
    {
        public Matrix4 View { get; set; }
        public Matrix4 Projection { get; set; }
        public Matrix4 Scale { get; set; }
        public Matrix4 aaa { get; set; }
        public Camera()
        {
            View = Matrix4.One();
            Projection = Matrix4.One();
            aaa = new Matrix4(new float[,]
            {
                { 1,0,0,0},
                { 0,1,0,0},
                { 0,0,1,0},
                { 0,0,-1,1}
            });
            Scale = Matrix4.One();
        }
        public Vector3 Convert(Vector3 v)
        {
            Vector4 r = aaa * View *Scale*new Vector4(v);
            return new Vector3(r);
        }
        public void Scaler(float delta)
        {
            Scale = Matrix4.One() * new Matrix4(new float[,] {
                {-delta,0,0,0},
                {0,-delta,0,0 },
                {0,0,-delta,0 },
                {0,0,0,1 },
            });
        }
    }
}
