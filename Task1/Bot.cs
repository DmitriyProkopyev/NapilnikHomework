using System;

namespace Task1
{
    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon) =>
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));

        private void OnSeePlayer(Player player) => _weapon.Fire(player);
    }
}