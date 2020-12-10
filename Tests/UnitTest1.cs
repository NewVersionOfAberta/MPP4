using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        string code = @"
            namespace TestingNamespace {
                public class FirstClass
                {
                    public void firstMethod(int type) { }
                    public void secondMethod() { }
                }
    
                public class SecondClass
                {
                    private void firstMethod(string password) { }
                    public void secondMethod() { }
                }

                public class ThirdClass
                {
                    private static void firstMethod(string password) { }
                    private void secondMethod(string coded) { }
                }
            }";




        [TestMethod]
        public void getClassDeclaration_parseClass_rightClassName()
        {
            var parser = new Parser();
            var classes = parser.getClassDeclarations(parser.parse(code));
            Assert.AreEqual("SecondClass", classes.ElementAt(1).Identifier.ValueText);
        }



        [TestMethod]
        public void testCodeFromClassCode_2ClassCodes_equal()
        {
            var parser = new Parser();
            var generator = new Generator(parser);
            Assert.AreEqual(generator.testCodeFromClassCode(code), generator.testCodeFromClassCode(code));
        }

        [TestMethod]
        public void testCodeFromClassCode_invalidText_()
        {
            var parser = new Parser();
            var generator = new Generator(parser);
            Assert.ThrowsException<SyntaxException>(() => generator.testCodeFromClassCode("Hello?"));
        }
    }
}