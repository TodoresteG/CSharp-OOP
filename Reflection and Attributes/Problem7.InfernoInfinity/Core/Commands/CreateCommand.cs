using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class CreateCommand : Command
    {
        public CreateCommand(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data, gemFactory, repository, weaponFactory)
        {
        }

        public override void Execute()
        {
            string[] tokens = this.Data[0].Split(' ');

            string rarity = tokens[0];
            string type = tokens[1];

            string name = this.Data[1];

            IWeapon weapon = this.WeaponFactory.CreateWeapon(rarity, type, name);

            this.Repository.AddWeapon(weapon);
        }
    }
}
