using System;
using ijunior.Reasons;
using ijunior.Weapons;

namespace ijunior
{
    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Reason reasonToFire = _weapon.CanFire();
            if (reasonToFire)
                _weapon.Fire(player);
            else
                reasonToFire.Visit(_weapon);
        }
    }
}