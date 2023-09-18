namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using NUnit.Framework;

    internal class RoundDegreesDown_Tests
    {
        [Theory]
        [TestCase( 10, 10)]
        [TestCase( 11, 10)]
        [TestCase( 12, 10)]
        [TestCase( 13, 10)]
        [TestCase( 14, 10)]
        [TestCase( 15, 10)]
        [TestCase( 16, 20)]
        [TestCase( 17, 20)]
        [TestCase( 18, 20)]
        [TestCase( 19, 20)]
        [TestCase( 20, 20)]
        public void Resolve(double? value, double expected)
        {
            //Arrange
            //Act
            var result = RoundDegreesDown.Resolve(value);
            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}