using ijunior.Weapons;

namespace ijunior.Reasons
{
    public class NotHaveAmmoReason : Reason
    {
        public override string ToString() => "Out of bullets, recharge is required";
        protected override bool IsSatisfied() => false;

        public override void Visit(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}