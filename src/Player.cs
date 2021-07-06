using System;

namespace ijunior
{
    public class Player : IDamageable
    {
        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));
            Health = health;
        }

        public int Health { get; private set; }

        public void Damage(int amount)
        {
            if (Health <= 0)
                throw new InvalidOperationException();

            Health = Math.Clamp(Health - amount, 0, int.MaxValue);

            if (Health == 0)
                Died?.Invoke();
        }

        public event Action Died;
    }
}