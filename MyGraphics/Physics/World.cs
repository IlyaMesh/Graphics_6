using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGraphics.Models;
using LibraryForThisTask;

namespace MyGraphics.Physics
{
    public class World
    {
        public float G { get; set; }
        public Missile rocket { get; set; }
        //public Vector3 Pos { get; set; }
        public World(Missile rock,Vector3 pos)
        {
            //Pos = pos;
            rocket = rock;
            G = 9.8f;
        }
        public void Update(float t)
        {
            if (rocket == null)
                return;
            if (rocket.Pos.Z < 0)
                return;
            float posx = rocket.Pos.X + rocket.Velocity * (float)Math.Cos(rocket.Angle) * t;
            // float posz = rocket.Pos.Z + (rocket.Velocity * (float)Math.Sin(rocket.Angle) - G * t) * t - ((G * t * t)/2);
            float posz = posx * (float)Math.Tan(rocket.Angle) - (G * posx * posx) / (2 * rocket.Velocity * rocket.Velocity * (float)Math.Cos(rocket.Angle) * (float)Math.Cos(rocket.Angle));
            rocket.Pos = new Vector3(posx,0,posz);
            //Bike.Velocity = v;
            //Bike.Position = pos;
            
        }
    }
}
