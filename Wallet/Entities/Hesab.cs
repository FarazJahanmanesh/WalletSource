using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Entities
{
    class Hesab
    {
        List<Tarakonesh> listTarakonesh ;
        public int HesabId { get; set; }
        public int Mojodi { get; set; }
        public DateTime DateMakeHesab { get; set; }

        public Hesab()
        {
            listTarakonesh = new List<Tarakonesh>();
        }
        public void AddTarakonesh(int idtrakonesh,int meqdartrakonesh)
        {
            Tarakonesh tarakonesh = new();
            tarakonesh.TrakoneshId = idtrakonesh;
            tarakonesh.TrakoneshMeqdar = meqdartrakonesh;
            Mojodi = Mojodi+tarakonesh.TrakoneshMeqdar ;
        }
        public void RemoveTarakonesh(int id)
        {
            var tarakonesh = listTarakonesh.Single(a=>a.TrakoneshId == id);
            //meqdar kam nemkoneh
            listTarakonesh.Remove(tarakonesh);
        }
        public void ShowMojodi(int idhesab)
        {
            Console.WriteLine($"mojodi is {Mojodi}");
        }
        public void ShowAllTarakonesh()
        {
            foreach (var tarakonesh in listTarakonesh)
            {
                Console.WriteLine("Id : " + tarakonesh.TrakoneshId + " Meqdar : " + tarakonesh.TrakoneshMeqdar);
            }
        }
    }
}
