using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [SetUp]
        public void Setup()
        {
            _player = new Player(Health);
        }

        private const int Health = 10;
        
        private Player _player;

        [Test]
        public void CreateDeadPlayer()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Player(0));
        }

        [Test]
        public void CreatePlayerWithNegativeHealth()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Player(-100));
        }

        [Test]
        public void Damage()
        {
            _player.Damage(5);
        }

        [Test]
        public void DamageAllHealth()
        {
            var playerIsDied = false;
            _player.Died += () => playerIsDied = true;

            _player.Damage(Health);
            Assert.AreEqual(true, playerIsDied);
        }

        [Test]
        public void DamageAfterDie()
        {
            var playerIsDied = false;
            _player.Died += () => playerIsDied = true;

            _player.Damage(Health);
            Assert.AreEqual(true, playerIsDied);

            Assert.Catch<InvalidOperationException>(() => _player.Damage(Health));
        }

        [Test]
        public void DamageMoreHaveHealth()
        {
            var playerIsDied = false;
            _player.Died += () => playerIsDied = true;

            _player.Damage(Health + 1);
            Assert.AreEqual(true, playerIsDied);
        }
    }
}