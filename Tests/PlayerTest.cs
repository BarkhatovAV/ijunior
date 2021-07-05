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
            var player = new Player(100);
        }

        [Test]
        public void CreateDeadPlayer()
        {
            Assert.Catch<ArgumentOutOfRangeException>((() => new Player(0)));
        }

        [Test]
        public void CreatePlayerWithNegativeHealth()
        {
            Assert.Catch<ArgumentOutOfRangeException>((() => new Player(-100)));
        }

        [Test]
        public void Damage()
        {
            const int health = 10;
            var player = new Player(health);
            player.Damage(5);
        }

        [Test]
        public void DamageAllHealth()
        {
            const int health = 10;
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(health);
            Assert.AreEqual(true, playerIsDied);
        }

        [Test]
        public void DamageAfterDie()
        {
            const int health = 10;
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(health);
            Assert.AreEqual(true, playerIsDied);

            Assert.Catch<InvalidOperationException>(() => player.Damage(health));
        }

        [Test]
        public void DamageMoreHaveHealth()
        {
            const int health = 10;
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            player.Damage(health + 1);
            Assert.AreEqual(true, playerIsDied);
        }
    }
}