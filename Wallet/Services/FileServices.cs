using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Configs;
using Wallet.Extensions;
using Wallet.Contracts;
using Wallet.Dtos;
using Wallet.Entities;

namespace Wallet.Services
{
    class FileServices : IFileServices
    {
        public UserDetailDto ReadUserandPass()
        {
            string fileUserAndPass = File.ReadAllText(AddressOfFile.addressFileUserAndPass);
            string[] UserAndPass = fileUserAndPass.Split(" ");
            return new UserDetailDto
            {
                UserName = UserAndPass[0],
                Password = UserAndPass[1]
            };
        }
        public void WriteUserandPass(string user, string pass)
        {
            File.WriteAllText(AddressOfFile.addressFileUserAndPass, $"user {user} pass {pass.SHA1HashCode()}");
        }

        public HesabDetailDto HesabShow()
        {
            var listIdHesabAndDateDto = new HesabDetailDto();  
            string[] HesabIdAndHesabDate = File.ReadAllLines(AddressOfFile.addressFileListHesab);
            foreach (string b in HesabIdAndHesabDate)
            {
                string[] SplitHesabIdAndHesabDate = b.Split(" ");
                listIdHesabAndDateDto.listIdHesab.Add(int.Parse(SplitHesabIdAndHesabDate.First()));
                listIdHesabAndDateDto.DateMakeHesab.Add(DateTime.Parse(SplitHesabIdAndHesabDate[1]));
            }
            for (int i = 0; i < listIdHesabAndDateDto.listIdHesab.Count; i++)
            {
                Console.WriteLine("id : " + listIdHesabAndDateDto.listIdHesab[i] + " date : " + listIdHesabAndDateDto.DateMakeHesab[i].ToShortDateString());
            }
            return new HesabDetailDto
            {
                listIdHesab = listIdHesabAndDateDto.listIdHesab,
                DateMakeHesab = listIdHesabAndDateDto.DateMakeHesab
            };

        }
        public HesabDetailDto RemoveHesab(int idremove)
        {
            var listIdHesabAndDateDto = new HesabDetailDto();
            string[] HesabIdAndHesabDate = File.ReadAllLines(AddressOfFile.addressFileListHesab);
            foreach (string b in HesabIdAndHesabDate)
            {
                string[] SplitHesabIdAndHesabDate = b.Split(" ");
                listIdHesabAndDateDto.listIdHesab.Add(int.Parse(SplitHesabIdAndHesabDate.First()));
                listIdHesabAndDateDto.DateMakeHesab.Add(DateTime.Parse(SplitHesabIdAndHesabDate[1]));
            }
            foreach (string b in HesabIdAndHesabDate)
            {
                string[] SplitHesabIdAndHesabDate = b.Split(" ");
                if (idremove == int.Parse(SplitHesabIdAndHesabDate[0]))
                {
                    listIdHesabAndDateDto.listIdHesab.Remove(idremove);
                    listIdHesabAndDateDto.DateMakeHesab.Remove(DateTime.Parse(SplitHesabIdAndHesabDate[1]));
                }
            }
            List<string> NewHesabIdAndHesabDate = new();
            for (int i = 0; i < listIdHesabAndDateDto.listIdHesab.Count; i++)
            {
                NewHesabIdAndHesabDate.Add(listIdHesabAndDateDto.listIdHesab[i] + " " + listIdHesabAndDateDto.DateMakeHesab[i].ToShortDateString());
            }
            File.WriteAllLines(AddressOfFile.addressFileListHesab, NewHesabIdAndHesabDate);
            return new HesabDetailDto
            {
                listIdHesab = listIdHesabAndDateDto.listIdHesab,
                DateMakeHesab = listIdHesabAndDateDto.DateMakeHesab
            };
        }
        public HesabDetailDto MakeHesab(int idhesab)
        {
            var listIdHesabAndDateDto = new HesabDetailDto();
            string[] HesabIdAndHesabDate = File.ReadAllLines(AddressOfFile.addressFileListHesab);
            foreach (string b in HesabIdAndHesabDate)
            {
                string[] SplitHesabIdAndHesabDate = b.Split(" ");
                listIdHesabAndDateDto.listIdHesab.Add(int.Parse(SplitHesabIdAndHesabDate.First()));
                listIdHesabAndDateDto.DateMakeHesab.Add(DateTime.Parse(SplitHesabIdAndHesabDate[1]));
            }
            listIdHesabAndDateDto.listIdHesab.Add(idhesab);
            listIdHesabAndDateDto.DateMakeHesab.Add(DateTime.Now);
            List<string> NewHesabIdAndHesabDate = new();
            for (int i = 0; i < listIdHesabAndDateDto.listIdHesab.Count; i++)
            {
                NewHesabIdAndHesabDate.Add(listIdHesabAndDateDto.listIdHesab[i] + " " + listIdHesabAndDateDto.DateMakeHesab[i].ToShortDateString());
            }
            File.WriteAllLines(AddressOfFile.addressFileListHesab, NewHesabIdAndHesabDate);
            return new HesabDetailDto
            { 
                listIdHesab = listIdHesabAndDateDto.listIdHesab,
                DateMakeHesab = listIdHesabAndDateDto.DateMakeHesab 
            };
        }
        public HesabDetailDto CheackHesabExists(int idhesab)
        {
            var listIdHesabAndDateDto = new HesabDetailDto();
            string[] HesabIdAndHesabDate = File.ReadAllLines(AddressOfFile.addressFileListHesab);
            foreach (string b in HesabIdAndHesabDate)
            {
                string[] SplitHesabIdAndHesabDate = b.Split(" ");
                listIdHesabAndDateDto.listIdHesab.Add(int.Parse(SplitHesabIdAndHesabDate.First()));
                listIdHesabAndDateDto.DateMakeHesab.Add(DateTime.Parse(SplitHesabIdAndHesabDate[1]));
            }
            if (listIdHesabAndDateDto.listIdHesab.Contains(idhesab))
            {
                return new HesabDetailDto
                {
                    HesabExists = true 
                };
            }
            else
            {
                return new HesabDetailDto
                {
                    HesabExists = false 
                };
            }
        }

        public TarakoneshDetailDto TarakonsehHesab(int idhesab)
        {
            var tarakoneshDto = new TarakoneshDetailDto();
            string[] IdHesabIdTarakoneshMeqdarDate = File.ReadAllLines(AddressOfFile.addressFileListTarakonesh);
            foreach (var a in IdHesabIdTarakoneshMeqdarDate)
            {
                string[] SplitIdHesabIdTarakoneshMeqdarDate = a.Split(" ");
                tarakoneshDto.listIdHesabTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]));
                tarakoneshDto.listIdTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[1]));
                tarakoneshDto.listMeqdarTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[2]));
                tarakoneshDto.DateTarakonseh.Add(DateTime.Parse(SplitIdHesabIdTarakoneshMeqdarDate[3]));
            }
            for (int i = 0; i < tarakoneshDto.listIdTarakonseh.Count; i++)
            {
                if (tarakoneshDto.listIdHesabTarakonseh[i] == idhesab)
                {
                    Console.WriteLine("hesab id :" + tarakoneshDto.listIdHesabTarakonseh[i] + " tarakonseh id :" + tarakoneshDto.listIdTarakonseh[i] + " meqdar : " + tarakoneshDto.listMeqdarTarakonseh[i] + " date : " + tarakoneshDto.DateTarakonseh[i].ToShortDateString());
                }
            }
            return new TarakoneshDetailDto
            {
                DateTarakonseh = tarakoneshDto.DateTarakonseh,
                listIdHesabTarakonseh = tarakoneshDto.listIdHesabTarakonseh,
                listIdTarakonseh = tarakoneshDto.listIdTarakonseh,
                listMeqdarTarakonseh = tarakoneshDto.listMeqdarTarakonseh
            };
        }
        public TarakoneshDetailDto AddTarakonseh(int idhesab, int idtarakonesh, int meqdar)
        {
            var tarakoneshDto = new TarakoneshDetailDto();
            string[] IdHesabIdTarakoneshMeqdarDate = File.ReadAllLines(AddressOfFile.addressFileListTarakonesh);
            foreach (var a in IdHesabIdTarakoneshMeqdarDate)
            {
                string[] SplitIdHesabIdTarakoneshMeqdarDate = a.Split(" ");
                tarakoneshDto.listIdHesabTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]));
                tarakoneshDto.listIdTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[1]));
                tarakoneshDto.listMeqdarTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[2]));
                tarakoneshDto.DateTarakonseh.Add(DateTime.Parse(SplitIdHesabIdTarakoneshMeqdarDate[3]));
            }
            tarakoneshDto.listIdHesabTarakonseh.Add(idhesab);
            tarakoneshDto.listIdTarakonseh.Add(idtarakonesh);
            tarakoneshDto.listMeqdarTarakonseh.Add(meqdar);
            tarakoneshDto.DateTarakonseh.Add(DateTime.Now);
            List<string> NewIdHesabIdTarakoneshMeqdarDate = new();
            for (int i = 0; i < tarakoneshDto.listIdTarakonseh.Count; i++)
            {
                NewIdHesabIdTarakoneshMeqdarDate.Add(tarakoneshDto.listIdHesabTarakonseh[i] + " " + tarakoneshDto.listIdTarakonseh[i] + " " + tarakoneshDto.listMeqdarTarakonseh[i] + " " + tarakoneshDto.DateTarakonseh[i].ToShortDateString());
            }
            File.WriteAllLines(AddressOfFile.addressFileListTarakonesh, NewIdHesabIdTarakoneshMeqdarDate);
            return new TarakoneshDetailDto
            {
                DateTarakonseh = tarakoneshDto.DateTarakonseh,
                listIdHesabTarakonseh = tarakoneshDto.listIdHesabTarakonseh,
                listIdTarakonseh = tarakoneshDto.listIdTarakonseh,
                listMeqdarTarakonseh = tarakoneshDto.listMeqdarTarakonseh 
            };
        }
        public TarakoneshDetailDto RemoveTarakonseh(int idremove, int idhesab)
        {
            var tarakoneshDto = new TarakoneshDetailDto();
            string[] IdHesabIdTarakoneshMeqdarDate = File.ReadAllLines(AddressOfFile.addressFileListTarakonesh);
            foreach (var a in IdHesabIdTarakoneshMeqdarDate)
            {
                string[] SplitIdHesabIdTarakoneshMeqdarDate = a.Split(" ");
                tarakoneshDto.listIdHesabTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]));
                tarakoneshDto.listIdTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[1]));
                tarakoneshDto.listMeqdarTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[2]));
                tarakoneshDto.DateTarakonseh.Add(DateTime.Parse(SplitIdHesabIdTarakoneshMeqdarDate[3]));
            }
            foreach (var a in IdHesabIdTarakoneshMeqdarDate)
            {
                string[] SplitIdHesabIdTarakoneshMeqdarDate = a.Split(" ");
                if (int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]) == idhesab && int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[1]) == idremove)
                {
                    tarakoneshDto.listIdHesabTarakonseh.Remove(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]));
                    tarakoneshDto.listIdTarakonseh.Remove(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[1]));
                    tarakoneshDto.listMeqdarTarakonseh.Remove(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[2]));
                    tarakoneshDto.DateTarakonseh.Remove(DateTime.Parse(SplitIdHesabIdTarakoneshMeqdarDate[3]));
                }
            }
            List<string> NewIdHesabIdTarakoneshMeqdarDate = new();
            for (int i = 0; i < tarakoneshDto.listIdTarakonseh.Count; i++)
            {
                NewIdHesabIdTarakoneshMeqdarDate.Add(tarakoneshDto.listIdHesabTarakonseh[i] + " " + tarakoneshDto.listIdTarakonseh[i] + " " + tarakoneshDto.listMeqdarTarakonseh[i] + " " + DateTime.Now.ToShortDateString());
            }
            File.WriteAllLines(AddressOfFile.addressFileListTarakonesh, NewIdHesabIdTarakoneshMeqdarDate);
            return new TarakoneshDetailDto
            {
                DateTarakonseh = tarakoneshDto.DateTarakonseh,
                listIdHesabTarakonseh = tarakoneshDto.listIdHesabTarakonseh,
                listIdTarakonseh = tarakoneshDto.listIdTarakonseh, 
                listMeqdarTarakonseh = tarakoneshDto.listMeqdarTarakonseh 
            };
        }
        public int Mojodi(int idhesab)
        {
            var tarakoneshDto = new TarakoneshDetailDto();
            string[] IdHesabIdTarakoneshMeqdarDate = File.ReadAllLines(AddressOfFile.addressFileListTarakonesh);
            foreach (var a in IdHesabIdTarakoneshMeqdarDate)
            {
                string[] SplitIdHesabIdTarakoneshMeqdarDate = a.Split(" ");
                if (int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[0]) == idhesab)
                {
                    tarakoneshDto.listMeqdarTarakonseh.Add(int.Parse(SplitIdHesabIdTarakoneshMeqdarDate[2]));
                }
            }
            return (tarakoneshDto.listMeqdarTarakonseh.Sum());
        }
        
    }
}
