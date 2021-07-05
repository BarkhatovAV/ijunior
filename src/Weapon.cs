using System;

namespace ijunior
{
    public class Weapon
    {
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Damage = damage;
            Bullets = bullets;
        }

        public int Bullets
        {
            get => _bullets;
            private set
            {
                _bullets = value;
                BulletCountChanged?.Invoke(_bullets);
            }
        }

        public int Damage { get; }

        public event Action<int> BulletCountChanged;

        public void Fire(IDamageable damageable)
        {
            if (damageable == null)
                throw new ArgumentNullException(nameof(damageable));
            if (Bullets <= 0)
                throw new InvalidOperationException("Out of bullets");
            damageable.Damage(Damage);
            Bullets -= 1;
        }

        public bool HaveAmmo() => Bullets > 0;
    }
}