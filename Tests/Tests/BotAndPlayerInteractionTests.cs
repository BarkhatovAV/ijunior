using System;
using ijunior.Weapons;
using NUnit.Framework;

namespace ijunior.Tests
{
    public class BotAndPlayerInteractionTests
    {
        private const int Damage = 10;
        private const int BulletCount = 10;

        private Bot _bot;
        private Player _player;
        private Weapon _weapon;

        private void Setup(int damage, int bulletCount, int health)
        {
            _weapon = new Weapon(damage, bulletCount);
            _bot = new Bot(_weapon);
            _player = new Player(health);
        }

        [Test]
        public void PlayerDied()
        {
            Setup(Damage, BulletCount, Damage * BulletCount);

            var playerIsDied = false;
            _player.Died += () => playerIsDied = true;

            for (int i = 0; i < BulletCount; i++)
                _bot.OnSeePlayer(_player);

            Assert.AreEqual(true, playerIsDied);
        }

        [Test]
        public void PlayerNotDied()
        {
            Setup(Damage, BulletCount, Damage * BulletCount + 1);

            var playerIsDied = false;
            _player.Died += () => playerIsDied = true;

            for (int i = 0; i < BulletCount; i++)
                _bot.OnSeePlayer(_player);

            Assert.AreEqual(false, playerIsDied);
        }

        [Test]
        public void ShootToDiedPlayer()
        {
            Setup(Damage, BulletCount, Damage);

            _bot.OnSeePlayer(_player);
            Assert.Catch<InvalidOperationException>(() => _bot.OnSeePlayer(_player));
        }
    }
}