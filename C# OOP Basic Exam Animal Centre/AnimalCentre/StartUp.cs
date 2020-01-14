using AnimalCentre.CommonContracts;
using AnimalCentre.CommonCotracts;
using AnimalCentre.Core;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IAnimalCentre animalCentre = new Core.AnimalCentre();

            IRunnable engine = new Engine(animalCentre);
            engine.Run();
        }
    }
}
