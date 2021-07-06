using System;

namespace ijunior
{
    public class Weapon
    {
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

        public event Action<int> BulletsChanged;

        public void Fire(IDamageable damageable)
        {
            if (damageable == null)
                throw new ArgumentNullException(nameof(damageable));
            if (Bullets <= 0)
                throw new InvalidOperationException("Out of bullets");
            damageable.Damage(Damage);
            Bullets -= 1;
            BulletsChanged?.Invoke(Bullets);
        }

        public bool HaveAmmo() => Bullets > 0;
    }
}