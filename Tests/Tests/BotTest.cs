using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class BotTest
    {
        [Test]
        public void CreateBot()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var bot = new Bot(weapon);
        }

        [Test]
        public void CreateBotWithoutWeapon()
        {
            Assert.Catch<ArgumentNullException>(() => new Bot(null));
        }

        [Test]
        public void UseMoreAmmunitionThanBotHave()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var bot = new Bot(weapon);
            var player = new Player(Int32.MaxValue);

            for (int i = 0; i < bulletsCount + 1; i++)
            {
                bot.OnSeePlayer(player);
            }
        }
    }
}