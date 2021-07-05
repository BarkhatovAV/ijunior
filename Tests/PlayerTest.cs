using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void CreatePlayer()
        {
            var health = new Health(100);
            var player = new Player(health);
        }

        [Test]
        public void CreatePlayerWithoutHealth()
        {
            Assert.Catch<ArgumentNullException>((() => new Player(null)));
        }

        [Test]
        public void Damage()
        {
            var health = new Health(10);
            var player = new Player(health);
            player.Damage(5);
        }

        [Test]
        public void DamageAllHealth()
        {
            const int maxHealth = 10;
            var health = new Health(10);
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(maxHealth);
            Assert.AreEqual(true, playerIsDied);
        }

        [Test]
        public void DamageAfterDie()
        {
            const int maxHealth = 10;
            var health = new Health(maxHealth);
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(maxHealth);
            Assert.AreEqual(true, playerIsDied);

            Assert.Catch<InvalidOperationException>(() => player.Damage(maxHealth));
        }

        [Test]
        public void DamageMoreHaveHealth()
        {
            const int maxHealth = 10;
            var health = new Health(maxHealth);
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(maxHealth + 1);
            Assert.AreEqual(true, playerIsDied);
        }
    }
}