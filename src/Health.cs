using System;

namespace ijunior
{
    public class Health
    {
        private int _value;

        public Health(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            _value = value;
        }

        public int Value => _value;

        public void Damage(int amount)
        {
            if (_value <= 0)
                throw new InvalidOperationException();

            _value = Math.Clamp(_value - amount, 0, int.MaxValue);

            if (_value == 0)
                Die?.Invoke();
        }

        public event Action Die;
    }
}