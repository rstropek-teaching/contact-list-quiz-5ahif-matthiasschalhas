using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactListQuiz;
using ContactListQuiz.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ContactListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeletePersonErrorCase()
        {
            ValuesController control = new ValuesController();
            var erg = (control.deletePerson(0) as ObjectResult).Value;
            Assert.AreEqual("Invalid ID supplied", erg);
        }

        [TestMethod]
        public void TestDeletePersonRightCase()
        {
            ValuesController control = new ValuesController();
            var erg = (control.deletePerson(2) as ObjectResult).Value;
            Assert.AreEqual("Successful operation", erg.ToString());
        }

        [TestMethod]
        public void TestGetPerson()
        {
            ValuesController control = new ValuesController();
            var erg = (control.GetById(3) as ObjectResult).Value;
            Assert.IsNotNull(erg);
        }
    }
}
