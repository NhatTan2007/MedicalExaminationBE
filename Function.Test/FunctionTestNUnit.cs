using MedicalExamination.Domain.Helper;
using NUnit.Framework;

namespace Function.Test
{
    public class FunctionTestNUnit
    {
        [TestFixture]
        public class HelperTest
        {
            [SetUp]
            public void Setup()
            {

            }

            [Test]
            public void RemoveDoubleSpace1()
            {
                string data = "   tên là      đây   ";
                Assert.AreEqual("tên là đây", Helper.RemoveDoubleSpaces(data));
            }

            [Test]
            public void FormatPersonName1()
            {
                string data = "   tôn thất      nhật Tân   ";
                Assert.AreEqual("Tôn Thất Nhật Tân", Helper.FormatPersonName(data));
            }
        }

    }
}