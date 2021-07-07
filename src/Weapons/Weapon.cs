using System;
using ijunior.Reasons;

namespace ijunior.Weapons
{
    public class Weapon : IWeapon, IWeaponVisitor
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
            if (CanFire() == false)
                throw new InvalidOperationException(CanFire().ToString());

            damageable.Damage(Damage);
            Bullets -= BulletsPerShot;

            BulletsChanged?.Invoke(Bullets);
        }

        public Reason CanFire() =>
            Bullets - BulletsPerShot >= 0
                ? (Reason) new AllRightReason()
                : new NotHaveAmmoReason();

        public void Visit(NotHaveAmmoReason reason)
        {
            Reload();
        }

        private void Reload()
        {
            Bullets = BulletsPerShot * 10;
        }
    }
}