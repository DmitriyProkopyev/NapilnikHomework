using System;

namespace Task1
{
    public class Player
    {
        private int _health;

        public Player(int health)
        {
            if (health < 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_health <= 0)
                throw new InvalidOperationException(nameof(_health));

            _health -= damage;

            if (_health < 0)
                _health = 0;
        }
    }
}