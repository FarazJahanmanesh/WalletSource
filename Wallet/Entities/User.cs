using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Entities
{
    class User
    {
        List<Hesab> listHesab;
        public string Name { get; set; }
        public string Familyname { get; set; }
        public int IdChange { get; set; }
        public DateTime Birth { get; set; }

        public User()
        {
            listHesab = new List<Hesab>();
        }
        public void MakeAccount(int hesabid)
        {
            Hesab hesab = new();
            hesab.HesabId = hesabid;
            listHesab.Add(hesab);
            Console.Clear();
            Console.WriteLine("heasab was Make\n");
        }
        public void DeleateAccount(int hesabid)
        {
            var hesab = listHesab.Where(b => b.HesabId == hesabid).SingleOrDefault();
            if (hesab == null)
            {
                Console.Clear();
                Console.WriteLine("the id is not find");
            }
            else
            {
                listHesab.Remove(hesab);
                Console.Clear();
                Console.WriteLine("hesab was Deleate\n");
            }
        }
        public void ShowAllAccount()
        {
            foreach (var hesab in listHesab)
            {
                Console.WriteLine("Id : " + hesab.HesabId + " Mojodi : " + hesab.Mojodi);
            }
        }
    }
}
