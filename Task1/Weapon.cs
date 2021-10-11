using System;

namespace Task1
{
    internal class Weapon
    {
        public readonly int Damage;

        public int BulletsCount { get; private set; }

        public Weapon(int damage, int bulletsCount)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bulletsCount < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsCount));

            Damage = damage;
            BulletsCount = bulletsCount;
        }

        public void Fire(Player player)
        {
            if (BulletsCount > 0)
            {
                player.TakeDamage(Damage);
                BulletsCount--;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(BulletsCount));
        }
    }
}