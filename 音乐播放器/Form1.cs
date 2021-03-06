﻿using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 音乐播放器
{
    public partial class Form1 : Form
    {
        SoundPlayer sound = new SoundPlayer();
        public static int index;
        public static int stop;
        List<string> vs = new List<string>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择音乐文件";
            ofd.InitialDirectory = @"D:\CloudMusic";
            ofd.Multiselect = true;
            ofd.Filter = "音乐文件|*.wav|所以文件|*.*";
            ofd.ShowDialog();
            string[] path = ofd.FileNames;
            for (int i = 0; i < path.Length; i++)
            {
                listBox1.Items.Add(Path.GetFileName(path[i]));
                vs.Add(path[i]);
            }

        }

        private void add(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                index = listBox1.SelectedIndex;
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
            else { 
            
            
            }
                
                

            
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 1) {
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
            else if (index == 0)
            {
                
                index = listBox1.Items.Count - 1;
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
            else
            {
               
                index--;
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 1)
            {
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
            else if (index == listBox1.Items.Count-1)
            {

                index = 0;
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
            else
            {
                index++;
                sound.SoundLocation = vs[index];
                listBox1.SelectedIndex = index;
                sound.Play();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (stop == 0)
            {
                sound.Stop();
                stop = 1;
            }
            else {
                stop = 0;
                sound.Play();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red, 30);  //画笔
            Point p1 = new Point(500, 500);
            Point p2 = new Point(100, 100);
            graphics.DrawLine(pen, p1, p2);
            Size size=new System.Drawing.Size(80,80);
            Rectangle rec = new Rectangle(new Point(80, 80), size);
            graphics.DrawRectangle(pen,rec);
            Thread.Sleep(1000);
            Font font = new Font("微软雅黑", 20, FontStyle.Bold);
            graphics.DrawString("大黑耗子", font, Brushes.Red, 170, 170);
            Thread.Sleep(1000);
            Font font1 = new Font("楷体", 20, FontStyle.Bold);
            graphics.DrawString("大黑耗子", font1, Brushes.Red, 210, 210);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yanz_chilck(object sender, EventArgs e)
        {
            Random rm = new Random();
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                int num = rm.Next(0,10);
                str += num;
            }
            Bitmap bmp = new Bitmap(920,200);
            Graphics g = Graphics.FromImage(bmp);
          
            for (int i = 0; i < 10; i++)
            {
                Point p1 = new Point(i*30,0);
                string[] fonts = {"微软雅黑","宋体","黑体","隶书","楷体" };
                Color[] color = { Color.Red, Color.Blue, Color.Yellow, Color.Turquoise };
                g.DrawString(str[i].ToString(),new Font(fonts[rm.Next(0,5)],80,FontStyle.Bold),new SolidBrush(color[rm.Next(0,4)]),p1);
            }
            for (int i = 0; i < 200; i++)
            {
                Point p1 = new Point(rm.Next(0, bmp.Width), rm.Next(0, bmp.Height));
                Point p2 = new Point(rm.Next(0, bmp.Width), rm.Next(0, bmp.Height));
                g.DrawLine(new Pen(Brushes.Green), p1, p2);
            }

            for (int i = 0; i < 500; i++)
            {
                Point p = new Point(rm.Next(0, bmp.Width), rm.Next(0, bmp.Height));
                Color[] color = { Color.Red, Color.Blue, Color.Yellow, Color.Turquoise, Color.AntiqueWhite, Color.Beige };
                bmp.SetPixel(p.X, p.Y, color[rm.Next(0, 4)]);
            }
            pictureBox1.Image = bmp;


        }
    }
}
