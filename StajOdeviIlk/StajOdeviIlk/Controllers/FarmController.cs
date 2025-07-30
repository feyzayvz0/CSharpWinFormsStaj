using StajOdeviIlk.Repository;
using StajOdeviIlk.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Controllers
{
    public class FarmController
    {
        private readonly ChickenService _chickenService;
        private readonly CowService _cowService;
        private readonly SheepService _sheepService;
        private readonly GooseService _gooseService;

        public FarmController(
            ChickenService chickenService,
            CowService cowService,
            SheepService sheepService,
            GooseService gooseService)
        {
            _chickenService = chickenService;
            _cowService = cowService;
            _sheepService = sheepService;
            _gooseService = gooseService;
        }

        // CHICKEN
        public bool FeedChicken() => _chickenService.FeedChicken();

        public int GetChickenUnsoldProductCount() => _chickenService.GetUnsoldProductCount();
        public bool HasAnyAliveChicken() => _chickenService.HasAnyAliveChicken();
        public void BuyChicken(decimal price) => _chickenService.BuyChicken(price);
        public bool HasEnoughChickenCash(decimal price) => _chickenService.GetCash() >= price;
        public int? GetAliveChickenAge()
        {
            var chicken = _chickenService.GetAliveChicken();
            return chicken?.Age;
        }
        public int SellChickenProducts(int qty, decimal price) => _chickenService.SellChickenProducts(qty, price);
        public decimal GetCash() => _chickenService.GetCash();

        // COW
        public bool FeedCow() => _cowService.ProduceMilk();
        public int GetCowUnsoldProductCount() => _cowService.GetUnsoldProductCount();
        public bool HasAnyAliveCow() => _cowService.GetAliveCow() != null;
        public void BuyCow(string gender, decimal price) => _cowService.BuyCow(gender, price);
        public bool HasEnoughCowCash(decimal price) => _cowService.GetCash() >= price;
        public int? GetAliveCowAge()
        {
            var cow = _cowService.GetAliveCow();
            return cow?.Age;
        }
        public int SellCowProducts(int qty, decimal price) => _cowService.SellCowProducts(qty, price);

        // SHEEP
        public bool FeedSheep() => _sheepService.ProduceWool();
        public int GetSheepUnsoldProductCount() => _sheepService.GetUnsoldProductCount();
        public bool HasAnyAliveSheep() => _sheepService.HasAnyAliveSheep();
        public void BuySheep(string gender, decimal price) => _sheepService.BuySheep(gender, price);
        public bool HasEnoughSheepCash(decimal price) => _sheepService.GetCash() >= price;
        public int? GetAliveSheepAge()
        {
            var sheep = _sheepService.GetAliveSheep();
            return sheep?.Age;
        }
        public int SellSheepProducts(int qty, decimal price) => _sheepService.SellSheepProducts(qty, price);

        // GOOSE
        public bool FeedGoose() => _gooseService.FeedGoose();
        public int GetGooseUnsoldProductCount() => _gooseService.GetUnsoldProductCount();
        public bool HasAnyAliveGoose() => _gooseService.HasAnyAliveGoose();
        public void BuyGoose(string gender, decimal price) => _gooseService.BuyGoose(gender, price);
        public bool HasEnoughGooseCash(decimal price) => _gooseService.GetCash() >= price;
        public int? GetAliveGooseAge()
        {
            var goose = _gooseService.GetAliveGoose();
            return goose?.Age;
        }
        public int SellGooseProducts(int qty, decimal price) => _gooseService.SellGooseProducts(qty, price);

        // Default chicken ekle (ilk açılışta çağırabilirsin)
        public void AddDefaultChicken()
        {
            if (!HasAnyAliveChicken())
                _chickenService.BuyChicken(20);
        }

        // Tüm kasayı (ayrı ayrı repository varsa toplayarak) getir
        public decimal GetTotalCash()
        {
            return _chickenService.GetCash() +
                   _cowService.GetCash() +
                   _sheepService.GetCash() +
                   _gooseService.GetCash();
        }

        // SHEEP spesifik fonksiyonlar (id ile erişim isteyen kodlar için)
        public int? GetAliveSheepId() => _sheepService.GetAliveSheepId();

        public int GetSheepAgeById(int sheepId) => _sheepService.GetSheepAgeById(sheepId);
        public string GetSheepGenderById(int sheepId) => _sheepService.GetSheepGenderById(sheepId);

        // GOOSE için cinsiyet güncelle (eğer serviste böyle fonksiyon varsa)
        public void UpdateGooseGender(int gooseId, string gender)
        {
            _gooseService.UpdateGooseGender(gooseId, gender);
        }
        public int SellWool(int qty, decimal price)
        {
            return _sheepService.SellSheepProducts(qty, price);
        }

        public int SellMilk(int qty, decimal price)
        {
            return _cowService.SellCowProducts(qty, price);
        }

        public int SellFeather(int qty, decimal price)
        {
            return _gooseService.SellGooseProducts(qty, price);
        }

        public int SellEggs(int qty, decimal price)
        {
            return _chickenService.SellChickenProducts(qty, price);
        }

    }
}
