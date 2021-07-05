namespace ijunior
{
    public class Weapon
    {
        private readonly int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            player.Damage(_damage);
            _bullets -= 1;
        }
    }
}