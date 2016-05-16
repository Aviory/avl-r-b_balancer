
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Paint
{
    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();
        }           

        private void button1_Click( object sender, EventArgs e )
        {            
            TreeChild treechild=new TreeChild();
            string s=tbArr.Text;
            string[] str=s.Split(',');
            int[] ar=new int[str.Length];
            int i=0;
            foreach ( string s1 in str )
            {
                ar[i++] = int.Parse(s1);                
            }
            int w = canvas.Width / 2;
            Graphics gr = canvas.CreateGraphics();
            treechild.Draw(gr, ar,w);            
        }
    }
}
