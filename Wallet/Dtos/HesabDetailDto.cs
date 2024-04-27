using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Dtos
{
    public class HesabDetailDto
    {
        public List<int> listIdHesab;
        public List<DateTime> DateMakeHesab;
        public bool HesabExists { get; set; }
        public HesabDetailDto()
        {
            listIdHesab = new();
            DateMakeHesab = new();
        }
    }
}
