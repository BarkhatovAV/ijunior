using ijunior.Weapons;

namespace ijunior.Reasons
{
    public class AllRightReason : Reason
    {
        protected override bool IsSatisfied() => true;

        public override void Visit(IWeaponVisitor visitor)
        {
        }

        public override string ToString() => "All Right";
    }
}