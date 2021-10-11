namespace Task1
{
    internal class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = new Weapon(weapon.Damage, weapon.BulletsCount);
        }

        private void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}