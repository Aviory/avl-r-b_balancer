using MyTree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//44,32,22,65,88,74,75
namespace WF_Paint
{
    class TreeChild : BsTree
    {
        public void Draw(Graphics gr, int[] arr,int w)
        {
            int x = w;
            int y = -45;
            init(arr);
            AVLsort(root);    
            DrawNode(root, w, x, y, gr);
        }
        private void DrawNode(Node p , int w, int x, int y, Graphics canvas)
        {
            if (p == null)
            {
                canvas.FillEllipse(Brushes.Black, x - 2, y + 48, 10, 10);
                return;
            }
            int xl = x - w / 2;
            int xr = x + w / 2;
            y += 50;
            //canvas.DrawEllipse(new Pen(Brushes.Black), x - 1, y - 3, 23, 23);
            canvas.DrawString(p.val.ToString(), new Font("Arial", 14), Brushes.Black, new Point(x-2, y));
            canvas.DrawString(p.balance.ToString(), new Font("Arial", 12), Brushes.Red, new Point(x +27, y-12));
            canvas.DrawLine(new Pen(Brushes.Brown), x + 10, y + 16, xl + 5, y + 48);
            canvas.DrawLine(new Pen(Brushes.Blue), x + 10, y + 16, xr + 5, y + 48);
            DrawNode(p.left,w / 2, xl, y, canvas);
            DrawNode(p.right,w / 2, xr, y, canvas);
        }
    }
}
