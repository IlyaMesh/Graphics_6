using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForThisTask
{
    public struct Matrix4
    {
        private float[,] matr;
        public Matrix4(float[,] m)
        {
            matr = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matr[i, j] = m[i, j];
        }
        public float this[int i, int j]
        {
            get { return matr[i, j]; }
            set { matr[i, j] = value; }
        }
        public static Matrix4 Zero()
        {
            return new Matrix4(new float[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } });
        }
        public static Matrix4 One()
        {
            return new Matrix4(new float[,]
            {
                { 1,0,0,0},
                { 0,1,0,0},
                { 0,0,1,0},
                { 0,0,0,1}
            });
        }
        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            Vector4 r = Vector4.Zero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    r[i] += m[i, j] * v[j];
            return r;
        }
        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 r = Matrix4.Zero();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        r[i, j] += m1[i, k] * m2[k, j];
            return r;
        }
        public static Matrix4 Rotate(int ia, float angle)
        {
            int a1 = (ia + 1) % 3;
            int a2 = (ia + 2) % 3;
            Matrix4 m = Matrix4.One();
            m[a1, a1] = (float)Math.Cos(angle);
            m[a1, a2] = (float)-Math.Sin(angle);
            m[a2, a1] = (float)Math.Sin(angle);
            m[a2, a2] = (float)Math.Cos(angle);
            return m;
        }
    }
}
