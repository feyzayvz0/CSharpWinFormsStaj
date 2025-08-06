using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repository;
using System.Linq;

namespace StajOdeviIlkNet8.Repository
{
    public class AnimalRepository(FarmDbContext context) : IAnimalRepository
    {
        private readonly FarmDbContext _context = context;

        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void KillAnimal(int animalId)
        {
            var animal = _context.Animals.Find(animalId);
            if (animal != null)
            {
                animal.IsAlive = false;
                _context.SaveChanges();
            }
        }

        public void IncrementAge(int animalId)
        {
            var animal = _context.Animals.Find(animalId);
            if (animal != null)
            {
                animal.Age += 1;
                _context.SaveChanges();
            }
        }

        public int GetAnimalAge(int animalId)
        {
            var animal = _context.Animals.Find(animalId);
            return animal?.Age ?? 0;
        }

        public string GetAnimalGender(int animalId)
        {
            var animal = _context.Animals.Find(animalId);
            return animal?.Gender ?? "Seçiniz"; 
        }





        public void UpdateAnimalGender(int animalId, string gender)
        {
            var animal = _context.Animals.Find(animalId);
            if (animal != null)
            {
                animal.Gender = gender;
                _context.SaveChanges();
            }
        }

        public bool HasAnyAliveAnimal(int speciesId)
        {
            return _context.Animals.Any(a => a.SpeciesId == speciesId && a.IsAlive);
        }

        public int? GetAliveAnimalId(int speciesId)
        {
            var animal = _context.Animals
                .FirstOrDefault(a => a.SpeciesId == speciesId && a.IsAlive);
            return animal?.Id;
        }

        public string? GetSheepGenderById(int sheepId)
        {
            var sheep = _context.Sheeps.FirstOrDefault(s => s.Id == sheepId);
            return sheep?.Gender;
        }

    }
}
