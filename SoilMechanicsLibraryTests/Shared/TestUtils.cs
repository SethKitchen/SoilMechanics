using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Shared;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Shared
{
    public class TestUtils
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DescriptionShouldReturnEmptyStringOnNonEnum()
        {
            string d = Utils.GetDescription<string>(null);
            Assert.IsEmpty(d);
        }

        [Test]
        public void DescriptionShouldReturnEmptyStringOnNoDescriptionEnum()
        {
            NoDescriptionEnumStub myEnum = NoDescriptionEnumStub.None;
            string d = Utils.GetDescription(myEnum);
            Assert.IsEmpty(d);
        }

        private enum NoDescriptionEnumStub
        {
            None,
        }
    }
}
