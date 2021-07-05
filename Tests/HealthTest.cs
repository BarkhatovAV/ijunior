using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class HealthTest
    {
        [Test]
        public void CreateHealth()
        {
            var maxHealth = 10;
            var health = new Health(maxHealth);
        }

        [Test]
        public void CreateHealthWithNegativeValue()
        {
            var maxHealth = -10;
            Assert.Catch<ArgumentOutOfRangeException>(() => new Health(maxHealth));
        }
    }
}