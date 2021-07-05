namespace ijunior
{
    public class Player
    {
        private int _health;

        public Player(int health)
        {
            _health = health;
        }

        public void Damage(int damage)
        {
            _health -= damage;
        }
    }
}