using System;
using NUnit.Framework;

namespace ijunior.Tests
{
    [TestFixture]
    public class WeaponTest
    {
        [Test]
        public void CreateWeapon()
        {
            var weapon = new Weapon(10, 10);
        }

        [Test]
        public void CreateEmptyWeapon()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(10, 0));
        }

        [Test]
        public void CreateWeaponWithNegativeAmmo()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(10, -100));
        }

        [Test]
        public void CreateWeaponWithoutDamage()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(0, 10));
        }

        [Test]
        public void CreateWeaponWithNegativeDamage()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Weapon(0, 10));
        }

        [Test]
        public void ShootAllAmmo()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var player = new Player(int.MaxValue);

            for (int i = 0; i < bulletsCount; i++)
            {
                weapon.Fire(player);
            }
        }

        [Test]
        public void ShootMoreAmmoThanTheirIs()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);
            var player = new Player(int.MaxValue);

            for (int i = 0; i < bulletsCount; i++)
            {
                weapon.Fire(player);
            }

            Assert.Catch<InvalidOperationException>(() => weapon.Fire(player));
        }

        [Test]
        public void ShootToEmpty()
        {
            const int damage = 10;
            const int bulletsCount = 10;

            var weapon = new Weapon(damage, bulletsCount);

            Assert.Catch<ArgumentNullException>(() => weapon.Fire(null));
        }
    }
}