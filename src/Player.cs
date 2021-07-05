using System;

namespace ijunior
{
    public class Player : IDamageable
    {
        private readonly Health _health;

        public Player(Health health)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public int Health => _health.Value;

        public void Damage(int amount)
        {
            _health.Damage(amount);
        }

        public event Action Die
        {
            add => _health.Die += value;
            remove => _health.Die -= value;
        }
    }
}