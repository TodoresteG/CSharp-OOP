using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AnimalCentre.CommonContracts;
using AnimalCentre.CommonCotracts;
using AnimalCentre.Core.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre : IAnimalCentre
    {
        private readonly IProcedure chip;
        private readonly IProcedure dentalCare;
        private readonly IProcedure fitness;
        private readonly IProcedure nailTrim;
        private readonly IProcedure play;
        private readonly IProcedure vaccinate;

        private readonly List<IProcedure> procedures;

        private readonly IHotel hotel;

        private readonly IAnimalFactory animalFactory;

        private readonly Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
            this.procedures = new List<IProcedure>();
            this.AddAllProcedures();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.chip.DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.vaccinate.DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.fitness.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.play.DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.dentalCare.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = this.IsAnimalExist(name);

            this.nailTrim.DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            string result = string.Empty;

            IAnimal animal = this.IsAnimalExist(animalName);

            if (animal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                result = $"{owner} adopted animal without chip";
            }

            if (this.adoptedAnimals.ContainsKey(owner) == false)
            {
                this.adoptedAnimals[owner] = new List<string>();
            }

            this.adoptedAnimals[owner].Add(animalName);

            this.hotel.Adopt(animalName, owner);

            return result;
        }

        public string History(string type)
        {
            IProcedure procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == type);

            string result = procedure.History(type);

            return result;
        }

        public string PrintAdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.adoptedAnimals.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {kvp.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", kvp.Value)}");
            }

            return sb.ToString().TrimEnd();
        }

        private IAnimal IsAnimalExist(string name)
        {
            if (hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];

            return animal;
        }

        private void AddAllProcedures()
        {
            this.procedures.Add(this.chip);
            this.procedures.Add(this.dentalCare);
            this.procedures.Add(this.fitness);
            this.procedures.Add(this.nailTrim);
            this.procedures.Add(this.play);
            this.procedures.Add(this.vaccinate);
        }
    }
}
