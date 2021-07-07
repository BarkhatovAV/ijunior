using ijunior.Weapons;

namespace ijunior.Reasons
{
    public abstract class Reason
    {
        public static implicit operator bool(Reason reason) => reason.IsSatisfied();

        protected abstract bool IsSatisfied();

        public abstract void Visit(IWeaponVisitor visitor);
    }
}