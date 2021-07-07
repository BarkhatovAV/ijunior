using ijunior.Reasons;

namespace ijunior.Weapons
{
    public interface IWeapon
    {
        void Fire(IDamageable damageable);
        Reason CanFire();
    }
}