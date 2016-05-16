using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITree;
using MyTree;
using System.Windows.Forms;
using System.Drawing;


namespace MyTree
{
    public class BsTree : ITree.ITree, ICloneable
    {
       public class Node : ICloneable
        {
            public int val;
            public Node left;
            public Node right;
            public string color = "Red";
            public Node(int val)
            {
                this.val = val;
            }

            public Node()
            {
            }

            public override bool Equals(object obj)
            {
                Node node = obj as Node;
                if (node==null)
                {
                    return false;
                }
                return val.Equals(node.val) && left.Equals(node.left) && right.Equals(node.right);
            }

            public object Clone()
            {
                Node n = new Node(val);
                
                if (left != null)
                    n.left = (Node)left.Clone();
                if (right != null)
                    n.right = (Node)right.Clone();
                return n;
            }
        }
        public bool equalsNode(object pp)
        {
            Node p = pp as Node;
            if (p == null)
                return false;
            bool b = true;
            if(p.left!=null)
                b =Equals(p.left);          // L
            if(p.right!=null)
                b =Equals(p.right);         // R
            return b;
        }
        public Node root = null;

        public void init(int[] ar)
        {
            clear();
            foreach (int p in ar)
            {
                add(p);
            }
        }

        public void clear()
        {
            root = null;
        }

        public void add(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                root.color = "Black";
            }
            else
            {
                addNode(root, val);
            }
        }
        private void addNode(Node p, int val)
        {
            if (val < p.val)
            {
                if (p.left == null)
                {
                    p.left = new Node(val);
                    if (p.color == "Black")
                        p.left.color = "Red";
                    else
                        p.left.color = "Black";
                }
                else
                {
                    addNode(p.left, val);
                }
            }
            else
            {
                if (p.right == null)
                {
                    p.right = new Node(val);
                    if (p.color == "Black")
                        p.right.color = "Red";
                    else
                        p.right.color = "Black";
                }
                else
                {
                    addNode(p.right, val);
                }
            }
        }
        //public void deepLeft(Node p)
        //{
        //    if (p.left==null)
        //    {
        //        if (p.left == null)
        //        {
        //            p.left = new Node(val);
        //            if (p.color == "Black")
        //                p.left.color = "Red";
        //            else
        //                p.left.color = "Black";
        //        }
        //        else
        //        {
        //            addNode(p.left, val);
        //        }
        //    }
        //}
        public void AVLsort()
        {

        }

        public void print()
        {
            printNode(root);
        }
        private void printNode(Node p)
        {
            if (p == null)
                return;

            printNode(p.left);          // L
            Console.Write(p.val + " "); // V
            printNode(p.right);         // R
        }

        public int size()
        {
            int sizeofTree = 0;
            sizeNode(root, ref sizeofTree);
            return sizeofTree;
        }
        private void sizeNode(Node p, ref int c)
        {
            if (p == null)
            {
                return;
            }
            sizeNode(p.left, ref c);
            c++;
            sizeNode(p.right, ref c);
        }

        public int[] toArray()
        {
            int[] temp = new int[size()];
            int i = 0;
            ArrayNode(root, ref temp, ref i);
            return temp;
        }
        private void ArrayNode(Node p, ref int[] mine, ref int i)
        {
            if (p == null)
            {
                return;
            }
            ArrayNode(p.left, ref mine, ref i);
            mine[i++] = p.val;
            ArrayNode(p.right, ref mine, ref i);
        }
        public int nodes()
        {
            int AmmountOfNodes = 0;
            nodesNode(root, ref AmmountOfNodes);
            return AmmountOfNodes;
        }

        private void nodesNode(Node p, ref int i)
        {
            if (p == null)
            {
                return;
            }
            nodesNode(p.left, ref i);
            if (p.left != null || p.right != null)
            {
                i++;
            }
            nodesNode(p.right, ref i);
        }

        public int leafs()
        {
            int AmmountOfLeaves = 0;
            leafsNode(root, ref AmmountOfLeaves);
            return AmmountOfLeaves;
        }

        private void leafsNode(Node p, ref int i)
        {
            if (p == null)
            {
                return;
            }
            leafsNode(p.left, ref i);
            if (p.left == null && p.right == null)
            {
                i++;
            }
            leafsNode(p.right, ref i);
        }

        public void reverse()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                reverseNode(root);
            }

        }

        private void reverseNode(Node p)
        {
            if (p != null)
            {
                Node tmp = p.left;
                p.left = p.right;
                p.right = tmp;
                reverseNode(p.left);
                reverseNode(p.right);
            }

            else return;

        }

        public int height()
        {
            return heighNode(root);
        }

        private int heighNode(Node p)
        {
            if (p == null)
            {
                return -1;
            }
            return 1 + Math.Max(heighNode(p.left), heighNode(p.right));
        }

        public int width()
        {
            int maxWdth = 0;
            int i;
            int width = 0;
            int h = height();
            for (i = 1; i < h; i++)
            {
                width = widthNode(root, i);
                if (width > maxWdth)
                    maxWdth = width;
            }
            return maxWdth;
        }
        int widthNode(Node p, int level)
        {
            int res = 0;
            if (p == null) return res;
            if (level == 1) return 1;
            else if (level > 1)
                res = widthNode(p.left, level - 1) + widthNode(p.right, level - 1);
            widthNode(p.right, level - 1);
            return res;
        }

        public void del(int val)
        {

            if (root == null)
            {
                throw new NullReferenceException();
            }
            else if (size() == 1)
            {
                root = null;

            }
            else if (val == root.val)
            {
                Node p = root;
                Node prevNode = null;
                p = p.right;
                while (p != null)
                {
                    prevNode = p;
                    p = p.left;
                }
                int tmp = prevNode.val;
                del(prevNode.val);
                root.val = tmp;
            }
            else
            {
                Node p = root;
                Node prevNode = null;
                Node tmp = null;
                while (p.val != val || p.val != val)
                {
                    prevNode = p;
                    if (p.val > val) p = p.left;
                    else p = p.right;
                }
                if (prevNode.left == p)
                {
                    tmp = p;
                    if (tmp.right != null)
                    {
                        prevNode.left = tmp.right;
                        tmp.right = null;
                        prevNode.left.left = tmp.left;
                    }
                    else
                    {
                        prevNode.left = tmp.left;
                        tmp.left = null;
                    }
                }
                else
                {
                    tmp = p;
                    if (tmp.left != null)
                    {
                        prevNode.right = tmp.left;
                        tmp.left = null;
                        prevNode.right.right = tmp.right;
                    }
                    else
                    {
                        prevNode.right = tmp.right;
                        tmp.right = null;
                    }
                }
            }
        }

        public object Clone()
        {
            BsTree b = new BsTree();
            if (root != null)
                b.root = (Node) root.Clone();
            return b;
        }
    }
}
