using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data, gemFactory, repository, weaponFactory)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];
            int index = int.Parse(this.Data[1]);

            string[] tokens = this.Data[2].Split(' ');

            string clarity = tokens[0];
            string type = tokens[1];

            IGem gem = this.GemFactory.CreateGem(clarity, type);
            this.Repository.AddGem(name, index, gem);
        }
    }
}
