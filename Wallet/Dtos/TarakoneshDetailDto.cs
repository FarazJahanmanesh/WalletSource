using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Dtos
{
    public class TarakoneshDetailDto
    {
        public List<int> listIdHesabTarakonseh ;
        public List<int> listIdTarakonseh ;
        public List<int> listMeqdarTarakonseh ;
        public List<DateTime> DateTarakonseh ;
        public TarakoneshDetailDto()
        {
            listIdHesabTarakonseh = new ();
            listIdTarakonseh = new();
            listMeqdarTarakonseh = new();
            DateTarakonseh = new();
        }
    }
}
