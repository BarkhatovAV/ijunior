using ijunior.Reasons;

namespace ijunior.Weapons
{
    public interface IWeaponVisitor
    {
        void Visit(NotHaveAmmoReason reason);
    }
}