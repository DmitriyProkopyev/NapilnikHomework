using System;

namespace Task1
{
    internal class Player
    {
        private readonly int _maxHealth;

        public int Health { get; private set; }

        public Player(int maxHealth)
        {
            if (maxHealth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxHealth));

            _maxHealth = maxHealth;
            Health = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        private void Die() => Console.WriteLine("Я умер");
    }
}