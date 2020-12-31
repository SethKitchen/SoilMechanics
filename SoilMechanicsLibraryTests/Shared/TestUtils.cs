using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Shared;

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
    }
}
