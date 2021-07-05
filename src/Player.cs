using System;

namespace ijunior
{
    public class Player : IDamageable
    {
        private int _health;

        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));
            _health = health;
        }

        public int Health => _health;

        public void Damage(int amount)
        {
            if (Health <= 0)
                throw new InvalidOperationException();

            _health = Math.Clamp(Health - amount, 0, int.MaxValue);

            if (Health == 0)
                Die?.Invoke();
        }

        public event Action Die;
    }
}