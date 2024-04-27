using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Dtos;
using Wallet.Entities;

namespace Wallet.Contracts
{
    interface IFileServices
    {
        public UserDetailDto ReadUserandPass();
        public void WriteUserandPass(string user, string pass);

        public HesabDetailDto MakeHesab(int idhesab);
        public HesabDetailDto HesabShow();
        public HesabDetailDto CheackHesabExists(int idhesab);
        public HesabDetailDto RemoveHesab(int idremove);

        public TarakoneshDetailDto TarakonsehHesab(int idhesab);
        public TarakoneshDetailDto AddTarakonseh(int idhesab, int idtarakonesh, int meqdar);
        public TarakoneshDetailDto RemoveTarakonseh(int idremove, int idhesab);
        public int Mojodi(int idhesab);
    }
}
