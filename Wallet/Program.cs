using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Wallet.Extensions;
using Wallet.Entities;
using Wallet.Services;
using Wallet.Contracts;
using Wallet.Dtos;

namespace Wallet
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("F:\\New\\Data.Txt"))
            {
                Login();
            }
            else
            {
                Console.WriteLine("enter the user : ");
                string user = Console.ReadLine();
                Console.WriteLine("enter the pass :");
                string pass = Console.ReadLine();
                IFileServices fileServices = new FileServices();
                fileServices.WriteUserandPass(user, pass);
                Login();
            }
        }
        static void Login()
        {
            string user, pass;
            IFileServices fileServices = new FileServices();
            var userAndPass = fileServices.ReadUserandPass();
            while (true)
            {
                Console.WriteLine("enter the user : ");
                user = Console.ReadLine();
                Console.WriteLine("enter the pass :");
                pass = Console.ReadLine();
                if (user == userAndPass.UserName && pass.SHA1HashCode() == userAndPass.Password)
                {
                    Menu();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("pass or user its not correct");
                }
            }
        }
        static void Menu()
        { 
            while (true)
            {
                Console.WriteLine("\nfor Make:1 Delete:2 AllHesab:3 Account:4");
                int choiceHesab = int.Parse(Console.ReadLine());
                IFileServices fileServices = new FileServices();
                switch (choiceHesab)
                {
                    case 1:
                        Console.WriteLine("hesab id : ");
                        int hesabIdMake = int.Parse(Console.ReadLine());
                        fileServices.MakeHesab(hesabIdMake);
                        while (true)
                        {
                            Console.WriteLine("_______________________________________________________________");
                            Console.WriteLine("\nAddTarakonesh:1 DeleteTarakonesh:2 AllTarakonesh:3 ShowMojodi:4 BackToHesab:5");
                            int choiceTarakonesh = int.Parse(Console.ReadLine());
                            if (choiceTarakonesh == 5)
                            {
                                break;
                            }
                            else
                            {
                                switch (choiceTarakonesh)
                                {
                                    case 1:
                                        Console.WriteLine("enter the tarakonesh Id : ");
                                        int tarakoneshId = int.Parse(Console.ReadLine());
                                        Console.WriteLine("enter the tarakonesh meqdar : ");
                                        int tarakoneshMeqdar = int.Parse(Console.ReadLine());
                                        fileServices.AddTarakonseh(hesabIdMake, tarakoneshId, tarakoneshMeqdar);
                                        break;
                                    case 2:
                                        Console.WriteLine("enter the tarakonesh Id : ");
                                        int tarakoneshIdRemove = int.Parse(Console.ReadLine());
                                        fileServices.RemoveTarakonseh(tarakoneshIdRemove, hesabIdMake);
                                        break;
                                    case 3:
                                        Console.WriteLine("all tarakonesh is :");
                                        fileServices.TarakonsehHesab(hesabIdMake);
                                        break;
                                    case 4:
                                        Console.WriteLine($"mojodi is : {fileServices.Mojodi(hesabIdMake)}");
                                        break;
                                }
                            }
                            Console.WriteLine("\nfor end e or E :");
                            string choiceEndTarakonesh = Console.ReadLine();
                            if (choiceEndTarakonesh == "E" || choiceEndTarakonesh == "e")
                            {
                                Console.WriteLine("finish !!!");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                continue;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("entre the id want to Delete : ");
                        int idHesabDeleate = int.Parse(Console.ReadLine());
                        fileServices.RemoveHesab(idHesabDeleate);
                        break;
                    case 3:
                        Console.WriteLine("All Hesab Is :");
                        fileServices.HesabShow();
                        break;
                    case 4:
                        while (true)
                        {
                            Console.WriteLine("enter id hesab : ");
                            int iDHesab = int.Parse(Console.ReadLine());
                            var exists = fileServices.CheackHesabExists(iDHesab);
                            if (exists.HesabExists == true)
                            {
                                while (true)
                                {
                                    Console.WriteLine("_______________________________________________________________");
                                    Console.WriteLine("\nAddTarakonesh:1 DeleteTarakonesh:2 AllTarakonesh:3 ShowMojodi:4");
                                    int choiceTarakonesh = int.Parse(Console.ReadLine());
                                    switch (choiceTarakonesh)
                                    {
                                        case 1:
                                            Console.WriteLine("enter the tarakonesh Id : ");
                                            int tarakoneshId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("enter the tarakonesh meqdar : ");
                                            int tarakoneshMeqdar = int.Parse(Console.ReadLine());
                                            fileServices.AddTarakonseh(iDHesab, tarakoneshId, tarakoneshMeqdar);
                                            break;
                                        case 2:

                                            Console.WriteLine("enter the tarakonesh Id : ");
                                            int tarakoneshIdRemove = int.Parse(Console.ReadLine());
                                            fileServices.RemoveTarakonseh(tarakoneshIdRemove, iDHesab);
                                            break;
                                        case 3: 
                                            Console.WriteLine("all tarakonesh is :");
                                            fileServices.TarakonsehHesab(iDHesab);
                                            break;
                                        case 4:
                                            Console.WriteLine($"mojodi is : {fileServices.Mojodi(iDHesab)}");
                                            break;
                                    }
                                    Console.WriteLine("\nfor end e or E :");
                                    string choiceEndTarakonesh = Console.ReadLine();
                                    if (choiceEndTarakonesh == "E" || choiceEndTarakonesh == "e")
                                    {
                                        Console.WriteLine("finish !!!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("id not exists");
                            }
                            Console.WriteLine("\nenter e or E to end :");
                            string choiceEndAccount = Console.ReadLine();
                            if (choiceEndAccount == "E" || choiceEndAccount == "e")
                            {
                                Console.WriteLine("finish !!!");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                continue;
                            }
                        }
                        break;
                }
                Console.WriteLine("\nenter e or E to end :");
                string choiceEndHesab = Console.ReadLine();
                if (choiceEndHesab == "E" || choiceEndHesab == "e")
                {
                    Console.WriteLine("finish !!!");
                    break;
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}