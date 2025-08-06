using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repositories;
using StajOdeviIlkNet8.Repository;
using StajOdeviIlkNet8.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlkNet8.Controllers
{
    public class FarmController(
        ChickenService chickenService,
        CowService cowService,
        SheepService sheepService,
        GooseService gooseService)
    {
        private readonly ChickenService _chickenService = chickenService;
        private readonly CowService _cowService = cowService;
        private readonly SheepService _sheepService = sheepService;
        private readonly GooseService _gooseService = gooseService;

        // --- CHICKEN ---
        public bool FeedChicken() => _chickenService.FeedChicken();
        public int GetUnsoldEggCount() => _chickenService.GetUnsoldProductCount();
        public bool HasAliveChicken() => _chickenService.HasAnyAliveChicken();
        public void BuyChicken(decimal price) => _chickenService.BuyChicken(price);
        public decimal GetChickenCash() => _chickenService.GetCash();
        public int SellEggs(int qty, decimal price) => _chickenService.SellChickenProducts(qty, price);
        public int? GetAliveChickenAge() => _chickenService.GetAliveChicken()?.Age;
        public int? GetAliveChickenId() => _chickenService.GetAliveChicken()?.Id;

        // --- COW ---
        public bool FeedCow() => _cowService.ProduceMilk();
        public int GetUnsoldMilkCount() => _cowService.GetUnsoldProductCount();
        public bool HasAliveCow() => _cowService.GetAliveCow() != null;
        public void BuyCow(string gender, decimal price) => _cowService.BuyCow(gender, price);
        public decimal GetCowCash() => _cowService.GetCash();
        public int SellMilk(int qty, decimal price) => _cowService.SellCowProducts(qty, price);
        public int? GetAliveCowAge() => _cowService.GetAliveCow()?.Age;
        public int? GetAliveCowId() => _cowService.GetAliveCow()?.Id;

        // --- SHEEP ---
        public bool FeedSheep() => _sheepService.ProduceWool();
        public int GetUnsoldWoolCount() => _sheepService.GetUnsoldProductCount();
        public bool HasAliveSheep() => _sheepService.HasAnyAliveSheep();
        public void BuySheep(string gender, decimal price) => _sheepService.BuySheep(gender, price);
        public decimal GetSheepCash() => _sheepService.GetCash();
        public int SellWool(int qty, decimal price) => _sheepService.SellSheepProducts(qty, price);
        public int? GetAliveSheepAge() => _sheepService.GetAliveSheep()?.Age;
        public int? GetAliveSheepId() => _sheepService.GetAliveSheep()?.Id;
        public int GetSheepAgeById(int sheepId) => _sheepService.GetSheepAgeById(sheepId);
        public string? GetSheepGenderById(int sheepId) => _sheepService.GetSheepGenderById(sheepId);

        // --- GOOSE ---
        public bool FeedGoose() => _gooseService.FeedGoose();
        public int GetUnsoldFeatherCount() => _gooseService.GetUnsoldProductCount();
        public bool HasAliveGoose() => _gooseService.HasAnyAliveGoose();
        public void BuyGoose(string gender, decimal price) => _gooseService.BuyGoose(gender, price);
        public decimal GetGooseCash() => _gooseService.GetCash();
        public int SellFeather(int qty, decimal price) => _gooseService.SellGooseProducts(qty, price);
        public int? GetAliveGooseAge() => _gooseService.GetAliveGoose()?.Age;
        public int? GetAliveGooseId() => _gooseService.GetAliveGoose()?.Id;

      
        public decimal GetTotalCash()
        {
            return _chickenService.GetCash() +
                   _cowService.GetCash() +
                   _sheepService.GetCash() +
                   _gooseService.GetCash();
        }

    
        public void UpdateGooseGender(int gooseId, string gender)
        {
            _gooseService.UpdateGooseGender(gooseId, gender);
        }
        public bool HasAnyAliveSheep()
        {
            return _sheepService.HasAnyAliveSheep();
        }

        public bool HasAnyAliveChicken()
        {
            return _chickenService.HasAnyAliveChicken();
        }
        public int GetSheepAge()
        {
            var sheep = _sheepService.GetAliveSheep();
            return sheep?.Age ?? 0;
        }
        public int GetGooseAge()
        {
            var goose = _gooseService.GetAliveGoose();
            return goose?.Age ?? 0;
        }
        public int GetCowAge()
        {
            var cow = _cowService.GetAliveCow();
            return cow?.Age ?? 0;
        }

        public decimal GetCash()
        {
            return _chickenService.GetCash();
        }


        public int GetChickenUnsoldProductCount()
        {
            return _chickenService.GetUnsoldProductCount();
        }


        public int GetChickenAge()
        {

            var chicken = _chickenService.GetAliveChicken();
            return chicken?.Age ?? 0;
        }
        public Goose? GetAliveGoose()
        {
            return _gooseService.GetAliveGoose();
        }


        public void AddDefaultChicken()
        {
            if (!HasAliveChicken())
            {
                _chickenService.BuyChicken(20); 
            }
        }

    }
}