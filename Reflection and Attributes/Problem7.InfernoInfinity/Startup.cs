using Problem7.InfernoInfinity.Contracts;
using Problem7.InfernoInfinity.Core;
using Problem7.InfernoInfinity.Core.Commands;
using Problem7.InfernoInfinity.Core.Factories;
using Problem7.InfernoInfinity.Data;

namespace Problem7.InfernoInfinity
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IGemFactory gemFactory = new GemFactory();
            IRepository repository = new WeaponRepository();
            IWeaponFactory weaponFactory = new WeaponFactory();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(gemFactory, repository, weaponFactory);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
