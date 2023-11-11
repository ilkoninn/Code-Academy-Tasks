using BankConsoleApp.Exceptions.Bank_Exceptions;
using BankConsoleApp.Exceptions.User_Exceptions.Update_Exceptions;
using BankConsoleApp.Models.Check_Information_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models.User_Models
{
    internal static class DeleteBankCard
    {
        public static void DeleteAccount(User user)
        {
            Console.WriteLine("\n\tDelete Account section\n");
        PATH12:
            CheckBankInformation.GetCards(user);
            string userChoice = Console.ReadLine();
            if (userChoice == "0") return;
            if (int.TryParse(userChoice, out int choice))
            {
                BankCard userBankCard = CheckBankInformation.GetBankCard(user, choice);
                try
                {
                    if (userBankCard != null)
                    {
                    PATH13:
                        Console.Write("Please, enter card's pincode: ");
                        string userPincode = Console.ReadLine();
                        try
                        {
                            if (CheckUserInformation.CheckPincode(userPincode))
                            {
                                if(userBankCard.Pincode == int.Parse(userPincode)) 
                                {
                                    RemoveBankCard(user, userBankCard);
                                    Console.WriteLine("\nBank card successfully deleted!\n");
                                }
                                else
                                {
                                    throw new PincodeNotFoundException();
                                }
                            }
                            else
                            {
                                throw new InvalidPincodeException();
                            }
                        }
                        catch (PincodeNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH13;
                            }
                            return;
                        }
                        catch (InvalidPincodeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH13;
                            }
                            return;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n" + ex.Message);
                            Console.Write("Continue?(Y/N): ");
                            string yesOrNo = Console.ReadLine().ToLower().Trim();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                goto PATH13;
                            }
                            return;
                        }
                    }
                    else
                    {
                        throw new BankCardNotFoundException();
                    }
                }
                catch (BankCardNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH12;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("Continue?(Y/N): ");
                    string yesOrNo = Console.ReadLine().ToLower().Trim();
                    if (yesOrNo == "yes" || yesOrNo == "y")
                    {
                        goto PATH12;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again!\n");
                Console.Write("Continue?(Y/N): ");
                string yesOrNo = Console.ReadLine().ToLower().Trim();
                if (yesOrNo == "yes" || yesOrNo == "y")
                {
                    goto PATH12;
                }
            }
        }
        public static void RemoveBankCard(User user, BankCard bankCard)
        {
            string result;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            StringBuilder sb = new StringBuilder();
            foreach (var item in basePath.Split('\\'))
            {
                if (item == "bin") break;
                sb.Append(item + '\\');
            }

            string userJSONPath = sb + @"Bank Data" + @"\UserData.json";

            using (StreamReader sr = new StreamReader(userJSONPath))
            {
                result = sr.ReadToEnd();
            };

            var deserializeJson = JsonConvert.DeserializeObject<List<User>>(result);

            User newUser = deserializeJson.Find(u => u.UserId == user.UserId);
            newUser.bankCards.Remove(newUser.bankCards.Find(u => u.AccountId == bankCard.AccountId));

            var serializeJson = JsonConvert.SerializeObject(deserializeJson);

            using (StreamWriter sw = new StreamWriter(userJSONPath))
            {
                sw.WriteLine(serializeJson);
            }

        }
    }
}
