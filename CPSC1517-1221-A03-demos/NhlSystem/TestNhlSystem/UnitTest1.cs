using NhlSystem;
using System;
using System.Runtime.CompilerServices;

namespace TestNhlSystem
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Leon Draistal")]

        public void FullName_ValidName_FullNameSet(string fullName)
        {
            var validPerson = new Person(fullName);
            Assert.AreEqual(fullName, validPerson.FullName);
        }
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("     ")]

        public void FullName_InvalidName_ArgumentNullException(string fullName)
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => new Person(fullName));

            Assert.AreEqual("Full Name cannot be left empty", exception.ParamName);
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("BC")]
        [DataRow("  A  ")]

        public void FullName_InvalidName_ArgumentException(string fullname)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => new Person(fullname));

            Assert.AreEqual("Full Name must contain 3 or more characters", exception.Message);
        }
    }
}