using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trie;
using System;

namespace Trie.Tests
{
    [TestClass()]
    public class TrieTests
    {
        private Trie trie = new Trie();

        [TestInitialize]
        public void TestInitialize()
        {
            trie = new Trie();
        }

        [TestMethod()]
        public void AddIntoTrieAndCheckOfContain()
        {
            trie.Add("firstElement");
            trie.Add("cat");
            trie.Add("dog888");
            Assert.IsTrue(trie.Contains("firstElement") && trie.Contains("cat") && trie.Contains("dog888"));
        }

        [TestMethod()]
        public void RemoveAndAddEmptyElementFromEmptyTrie()
        {
            trie.Remove("");
            trie.Add("");
        }

        [TestMethod()]
        public void RemoveElementsFromTrie()
        {
            trie.Add("jkjhkjk");
            trie.Add("sssd");
            trie.Add("CS103");
            Assert.IsTrue(trie.Remove("sssd") && trie.Remove("CS103") && !trie.Remove("CS1003"));
        }

        [TestMethod()]
        public void CheckOfContainsWork()
        {
            trie.Add("jkjhkjk");
            trie.Add("sssd");
            trie.Add("CS103");
            Assert.IsTrue(trie.Contains("sssd") && !trie.Contains("CS104"));
        }

        [TestMethod()]
        public void CheckOfHowManyStartsWithPrefix()
        {
            trie.Add("sddd");
            trie.Add("sssd");
            trie.Add("ssssm");
            trie.Add("koi8");
            Assert.IsTrue(trie.HowManyStartsWithPrefix("s") == 3
                && trie.HowManyStartsWithPrefix("ko") == 1 && trie.HowManyStartsWithPrefix("sss") == 2);
        }

        [TestMethod()]
        public void SizeFromTrie()
        {
            trie.Add("sddd");
            trie.Add("sssd");
            trie.Add("pmpu");
            trie.Remove("sddd");
            trie.Remove("pmpu");
            Assert.IsTrue(trie.Size == 1);
        }

        [TestMethod()]
        public void RemoveThePrefixFromElementFromTrie()
        {
            trie.Add("sdfg");
            trie.Add("s");
            trie.Add("sdf");
            trie.Remove("s");
            trie.Remove("sdf");
            Assert.IsTrue(trie.Contains("sdfg"));
        }
    }
}