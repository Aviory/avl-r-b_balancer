using MyTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUnitTT
{
    [TestFixture]
    public class TestClass
    {
            [Test]
        [TestCase(new int[] { 5, 6, 7, 53, 1, 4 }, new int[] { 5, 6, 7, 53, 1, 4 })]
        public void equalsTest(int[] ini, int[] exp)
        {
            BsTree tree = new BsTree();
            tree.init(ini);
            ini.Equals(exp);
            Assert.AreEqual(exp, ini);
        }

        [Test]
        [TestCase(new int[] { 5, 6, 7, 53, 1, 4 }, 6, new int[] { 1, 4, 5, 6, 7, 53 })]
        public void delTest(int[] ini, int val, int[] exp)
        {
            BsTree tree = new BsTree();
            tree.init(ini);
            tree.del(val);
            ini.Equals(exp);
            Assert.AreEqual(exp, ini);
        }

        [Test]
        [TestCase(new int[] { 5, 7, 53, 1, 4 }, 6, new int[] { 1, 4, 5, 6, 7, 53 })]
        public void addTest(int[] ini, int val, int[] exp)
        {
            BsTree tree = new BsTree();
            tree.init(ini);
            tree.add(val);
            ini.Equals(exp);
            Assert.AreEqual(exp, ini);
        }
    }
}
