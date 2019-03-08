using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Tests
{
    [TestClass()]
    public class SubjectsTests
    {
        [TestMethod()]
        public void SubjectsTest()
        {
            Subjects mySubs = new Subjects();
            Subject s1 = new SchoolRecords.Subject("Geography", "A Level");
            mySubs.addSubject(ref s1);
            Subject s2 = new SchoolRecords.Subject("French", "A Level");
            mySubs.addSubject(ref s2);
            Assert.AreEqual(mySubs.getCurrentSize(),2);
        }

        [TestMethod()]
        public void getCurrentSizeTest()
        {
            Subjects mySubs = new Subjects();
            Assert.AreEqual(mySubs.getCurrentSize(), 0);
            Subject s1 = new SchoolRecords.Subject("French", "A Level");
            mySubs.addSubject(ref s1);
            Assert.AreEqual(mySubs.getCurrentSize(), 1);
        }

        [TestMethod()]
        public void addSubjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getSubjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getSubjectTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void removeSubjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}