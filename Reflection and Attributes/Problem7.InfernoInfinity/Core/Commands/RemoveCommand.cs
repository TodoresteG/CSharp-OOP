using Problem7.InfernoInfinity.Contracts;

namespace Problem7.InfernoInfinity.Core.Commands
{
    public class RemoveCommand : Command
    {
        public RemoveCommand(string[] data, IGemFactory gemFactory, IRepository repository, IWeaponFactory weaponFactory) 
            : base(data, gemFactory, repository, weaponFactory)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];
            int index = int.Parse(this.Data[1]);

            this.Repository.RemoveGem(name, index);
        }
    }
}
