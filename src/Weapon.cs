using System;

namespace ijunior
{
    public class Weapon
    {
        private const int BulletsPerShot = 1;

        public event Action<int> BulletsChanged;

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Damage = damage;
            Bullets = bullets;
        }

        public int Bullets { get; private set; }

        public int Damage { get; }

        public void Fire(IDamageable damageable)
        {
            if (damageable == null)
                throw new ArgumentNullException(nameof(damageable));
            if (HaveAmmo() == false)
                throw new InvalidOperationException("Out of bullets");

            damageable.Damage(Damage);
            Bullets -= BulletsPerShot;

            BulletsChanged?.Invoke(Bullets);
        }

        public bool HaveAmmo() => Bullets - BulletsPerShot >= 0;
    }
}