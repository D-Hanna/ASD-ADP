using Microsoft.VisualStudio.TestTools.UnitTesting;
using AVLSearchTreeProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLSearchTreeProj.Tests
{
    [TestClass()]
    public class AVLTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);

            Assert.IsTrue(tree.Search(10));
            Assert.IsTrue(tree.Search(20));
            Assert.IsTrue(tree.Search(30));
            Assert.IsTrue(tree.Search(40));
            Assert.IsTrue(tree.Search(50));
            Assert.IsTrue(tree.Search(25));
        }

        [TestMethod]
        public void DeleteTest()
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);

            tree.Delete(10);
            Assert.IsFalse(tree.Search(10));

            tree.Delete(20);
            Assert.IsFalse(tree.Search(20));

            tree.Delete(30);
            Assert.IsFalse(tree.Search(30));

            tree.Delete(40);
            Assert.IsFalse(tree.Search(40));

            tree.Delete(50);
            Assert.IsFalse(tree.Search(50));

            tree.Delete(25);
            Assert.IsFalse(tree.Search(25));
        }

        [TestMethod]
        public void SearchTest()
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            Assert.IsTrue(tree.Search(10));
            Assert.IsTrue(tree.Search(20));
            Assert.IsTrue(tree.Search(30));
            Assert.IsFalse(tree.Search(40));
        }

        [TestMethod]
        public void InOrderTraversalTest()
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                tree.InOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual("10 20 30", result);
            }
        }
    }
}