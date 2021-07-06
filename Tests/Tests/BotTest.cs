using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class BotTest
    {
        [SetUp]
        public void CreateBot()
        {
            _weapon = new Weapon(Damage, BulletsCount);
            _bot = new Bot(_weapon);
            _player = new Player(int.MaxValue);
        }

        private const int Damage = 10;
        private const int BulletsCount = 10;

        private Weapon _weapon;
        private Bot _bot;
        private Player _player;

        [Test]
        public void CreateBotWithoutWeapon()
        {
            Assert.Catch<ArgumentNullException>(() => new Bot(null));
        }

        [Test]
        public void UseMoreAmmunitionThanBotHave()
        {
            for (int i = 0; i < BulletsCount + 1; i++)
                _bot.OnSeePlayer(_player);
        }
    }
}