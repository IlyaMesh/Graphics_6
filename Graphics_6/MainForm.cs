using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGraphics;
using MyGraphics.Models;
using MyGraphics.Physics;
using LibraryForThisTask;

namespace Graphics_6
{
    public partial class MainForm : Form
    {
        private Scene scene;
        private Camera camera;
        private Missile missle;
        private World world;
        float current = 0;
        public MainForm()
        {
            InitializeComponent();
            scene = new Scene();
            camera = new Camera();
            missle = new Missile(new Vector3(0, 0, 0), new Vector3(0, 0, 30), 10f, 10f);
            //List<Vector3> axes = new List<Vector3>();
            //axes.Add(new Vector3(50, 0, 0));
            scene.Models.Add(new Line3D(new Vector3(0,0,0),new Vector3(100,0,0)));
            world = new World(missle,missle.Pos);
            scene.Models.Add(missle);
            MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = scene.DrawAll(camera,
                            new MyGraphics.Screen(Size,
                            new Rectangle(-100, -100, 200, 200)));
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }
        //DateTime lasttime = DateTime.Now;
        DateTime lasttime = new DateTime();
        private void drawTimer_Tick(object sender, EventArgs e)
        {
            //DateTime currenttime = DateTime.Now;
            // float dt = 0.001f * (currenttime - lasttime).Milliseconds;
            float t = 0.001f * (lasttime).Millisecond;
            world.Update(t);
            scene.Models[1].Pos = world.rocket.Pos;
            //lasttime = currenttime;
        }

        private void modelTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = missle.Pos.X.ToString() +"  "+ missle.Pos.Y.ToString() +"  "+ missle.Pos.Z.ToString() ;
            Invalidate();
        }
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            current -= e.Delta;
            camera.Scaler(current / 400);
            Invalidate();
        }
        Point last = new Point();
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            last = new Point();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            last = e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(!last.IsEmpty)
            {
                float dx = e.Location.X - last.X;
                float dy = e.Location.Y - last.Y;
                camera.View = 
                    Matrix4.Rotate(1, dx * (float)Math.PI / 180) *
                    Matrix4.Rotate(0, dy * (float)Math.PI / 180) *
                    camera.View;
                Invalidate();
                last = e.Location;
            }
            //last = e.Location;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                modelTimer.Start();
                drawTimer.Start();
                lasttime = DateTime.Now;
            }

            if(e.KeyCode==Keys.W)
            {
                world.rocket.Angle += (float)Math.PI / 12;
            }
        }
    }
}
