using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class WeaponTest
    {
        [SetUp]
        public void Setup()
        {
            _weapon = new Weapon(Damage, BulletsCount);
            _player = new Player(int.MaxValue);
        }

        private const int Damage = 10;
        private const int BulletsCount = 10;

        private Weapon _weapon;
        private IDamageable _player;

        [Test]
        public void CreateEmptyWeapon()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(Damage, 0));
        }

        [Test]
        public void CreateWeaponWithNegativeAmmo()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(Damage, -BulletsCount));
        }

        [Test]
        public void CreateWeaponWithoutDamage()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(0, BulletsCount));
        }

        [Test]
        public void CreateWeaponWithNegativeDamage()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(-Damage, BulletsCount));
        }

        [Test]
        public void ShootAllAmmo()
        {
            for (int i = 0; i < BulletsCount; i++)
                _weapon.Fire(_player);
        }

        [Test]
        public void ShootMoreAmmoThanTheirIs()
        {
            for (int i = 0; i < BulletsCount; i++)
                _weapon.Fire(_player);

            Assert.Catch<InvalidOperationException>(() => _weapon.Fire(_player));
        }

        [Test]
        public void ShootToEmpty()
        {
            Assert.Catch<ArgumentNullException>(() => _weapon.Fire(null));
        }
    }
}