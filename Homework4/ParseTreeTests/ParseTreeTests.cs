using NUnit.Framework;
using ParseTree;

namespace ParseTreeTests
{
    public class ParseTreeTests
    {

        [Test]
        public void TestWithStandartSequence()
        {
            string prefixSequence = "* (+ 2 3) (* 3 (- 8 6))";
            ParseTree.ParseTree parseTree = new();
            var indexForParseTreeCreation = -1;
            INode? newTree = parseTree.CreateNewNodeForParseTree(prefixSequence, ref indexForParseTreeCreation);
            parseTree.Eval(newTree);
            Assert.IsTrue(parseTree.Eval(newTree!) == 30);
        }

        [Test]
        public void TestWithNegativeBigNumbers()
        {
            string prefixSequence = "* (+ -804 300) -1";
            ParseTree.ParseTree parseTree = new();
            var indexForParseTreeCreation = -1;
            INode? newTree = parseTree.CreateNewNodeForParseTree(prefixSequence, ref indexForParseTreeCreation);
            parseTree.Eval(newTree);
            Assert.IsTrue(parseTree.Eval(newTree!) == 504);
        }

        [Test]
        public void TestWithDivisionByZero()
        {
            string prefixSequence = "* (/ -804 0) -1";
            ParseTree.ParseTree parseTree = new();
            var indexForParseTreeCreation = -1;
            INode? newTree = parseTree.CreateNewNodeForParseTree(prefixSequence, ref indexForParseTreeCreation);
            Assert.Throws<System.ArgumentException>(() => parseTree.Eval(newTree));
        }
    }
}