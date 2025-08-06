using StajOdeviIlkNet8;
using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StatisticsRepository
{
    private readonly FarmDbContext _context;

    public StatisticsRepository(FarmDbContext context) => _context = context;

    public List<StatisticsViewModel> GetStatistics()
    {
        decimal totalEarnedCash = _context.CashRegisters
            .Where(c => c.Amount > 0)
            .Sum(c => (decimal?)c.Amount) ?? 0;

        var result = _context.AnimalSpecies
            .Select(species => new StatisticsViewModel
            {
                AnimalType = species.Name,
                DeadAnimals = _context.Animals.Count(a => a.SpeciesId == species.Id && !a.IsAlive),

                EggsInStock = species.Name == "Chicken"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Egg" &&
                        !p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                EggsSold = species.Name == "Chicken"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Egg" &&
                        p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                MilkInStock = species.Name == "Cow"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Milk" &&
                        !p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                MilkSold = species.Name == "Cow"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Milk" &&
                        p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                WoolInStock = species.Name == "Sheep"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Wool" &&
                        !p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                WoolSold = species.Name == "Sheep"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Wool" &&
                        p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                FeathersInStock = species.Name == "Goose"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Feather" &&
                        !p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                FeathersSold = species.Name == "Goose"
                    ? _context.Products.Where(p =>
                        p.Animal != null && p.Animal.SpeciesId == species.Id &&
                        p.ProductType != null && p.ProductType.Name == "Feather" &&
                        p.IsSold
                    ).Sum(p => (int?)p.Quantity) ?? 0
                    : 0,

                TotalEarnedCash = totalEarnedCash
            })
            .OrderBy(x => x.AnimalType)
            .ToList();

        return result;
    }
}

