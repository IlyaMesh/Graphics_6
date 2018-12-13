using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMath
{
    public struct Vector4
    {
        private float[] crd;
        public Vector4(Vector3 v)
        {
            crd = new float[4] { v.X, v.Y, v.Z, 1 };
        }
       
        public Vector4(float x, float y, float z, float w = 1)
        {
            crd = new float[] { x, y, z, w };
        }
        public float X
        {
            get
            { return crd[0]; }
            set
            { crd[0] = value; }
        }
        public float Y
        {
            get
            { return crd[1]; }
            set
            { crd[1] = value; }
        }
        public float Z
        {
            get
            { return crd[2]; }
            set
            { crd[2] = value; }
        }
        public float W
        {
            get
            { return crd[3]; }
            set
            { crd[3] = value; }
        }
        public float this[int i] // перегрузка индексного оператора
        {
            get { return crd[i]; }
            set { crd[i] = value; }
        }
        public static Vector4 Zero()
        {
            return new Vector4(0, 0, 0, 0);
        }
        public Vector4 Normalized
        {
            get
            {
                if (Math.Abs(W) > 1e-10)
                    return new Vector4(X / W, Y / W, Z / W);
                else
                    return new Vector4(X, Y, Z, 0);
            }
        }
    }
}

