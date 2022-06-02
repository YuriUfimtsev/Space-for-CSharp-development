using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trie;
using System;

namespace Trie.Tests
{
    [TestClass]
    public class TrieTests
    {
        private Trie trie = new();

        [TestInitialize]
        public void TestInitialize()
        {
            trie = new Trie();
        }

        [TestMethod]
        public void AddIntoTrieAndCheckOfContain()
        {
            trie.Add("firstElement");
            trie.Add("cat");
            trie.Add("dog888");
            Assert.IsTrue(trie.Contain("firstElement"));
            Assert.IsTrue(trie.Contain("cat"));
            Assert.IsTrue(trie.Contain("dog888"));
        }

        [TestMethod]
        public void RemoveAndAddEmptyElementFromEmptyTrie()
        {
            trie.Remove("");
            trie.Add("");
        }

        [TestMethod]
        public void RemoveElementsFromTrie()
        {
            trie.Add("jkjhkjk");
            trie.Add("sssd");
            trie.Add("CS103");
            Assert.IsTrue(trie.Remove("sssd"));
            Assert.IsTrue(trie.Remove("CS103"));
            Assert.IsFalse(trie.Remove("CS1003"));
        }

        [TestMethod]
        public void CheckOfContainsWork()
        {
            trie.Add("jkjhkjk");
            trie.Add("sssd");
            trie.Add("CS103");
            Assert.IsTrue(trie.Contain("sssd"));
            Assert.IsFalse(trie.Contain("CS104"));
        }

        [TestMethod]
        public void CheckOfHowManyStartsWithPrefix()
        {
            trie.Add("sddd");
            trie.Add("sssd");
            trie.Add("ssssm");
            trie.Add("koi8");
            Assert.AreEqual(3, trie.HowManyStartsWithPrefix("s"));
            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("ko"));
            Assert.AreEqual(2, trie.HowManyStartsWithPrefix("sss"));
        }

        [TestMethod]
        public void SizeFromTrie()
        {
            trie.Add("sddd");
            trie.Add("sssd");
            trie.Add("pmpu");
            trie.Remove("sddd");
            trie.Remove("pmpu");
            Assert.AreEqual(trie.Size, 1);
        }

        [TestMethod]
        public void RemoveThePrefixFromElementFromTrie()
        {
            trie.Add("sdfg");
            trie.Add("s");
            trie.Add("sdf");
            trie.Remove("s");
            trie.Remove("sdf");
            Assert.IsTrue(trie.Contain("sdfg"));
        }
    }
}