using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    public class BotAndPlayerInteractionTests
    {
        [Test]
        public void PlayerDied()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var bot = new Bot(weapon);
            var health = new Health(damage * bulletsCount);
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            for (int i = 0; i < bulletsCount; i++)
            {
                bot.OnSeePlayer(player);
            }

            Assert.AreEqual(true, playerIsDied);
        }

        [Test]
        public void PlayerNotDied()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var bot = new Bot(weapon);
            var health = new Health(damage * bulletsCount + 1);
            var player = new Player(health);

            var playerIsDied = false;
            player.Die += () => playerIsDied = true;

            for (int i = 0; i < bulletsCount; i++)
            {
                bot.OnSeePlayer(player);
            }

            Assert.AreEqual(false, playerIsDied);
        }

        [Test]
        public void ShootToDiedPlayer()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var bot = new Bot(weapon);
            var health = new Health(damage);
            var player = new Player(health);

            bot.OnSeePlayer(player);
            Assert.Catch<InvalidOperationException>(() => bot.OnSeePlayer(player));
        }
    }
}