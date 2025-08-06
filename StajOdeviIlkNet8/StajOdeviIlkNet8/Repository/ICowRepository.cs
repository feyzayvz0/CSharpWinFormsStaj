using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Repository
{
    public interface ICowRepository
    {
        void Add(Cow cow);
        Cow? GetAliveCow();

        void UpdateGender(int cowId, string gender);
        void AgeUp(int cowId);
        void Kill(int cowId);
        List<Product> GetProducts(int cowId);

        void IncrementMilkCount(int cowId);    
        int GetAnimalAge(int cowId);

        void IncrementAge(int cowId);      
        int GetMilkCount(int cowId);
    }
}