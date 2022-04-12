using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool situationProgram = true;
            int chooseMenu;
            bool phoneNumberCheck = false;
            string phonenumber = string.Empty;
            bool chooseMenuCheck = false;
            bool flag = true;

            while (situationProgram)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(0) Çıkmak için\n");
                Console.Write("Seçim:");
                bool succesChoose = int.TryParse(Console.ReadLine(), out chooseMenu);
                flag = true;
                if (succesChoose && chooseMenu == 1)
                {
                    Console.WriteLine("-------- Yeni Numara Kaydetme Ekranı --------");
                    Console.Write("Lütfen isim giriniz      :");
                    string name = Console.ReadLine();
                    Console.Write("Lütfen soysim giriniz    :");
                    string surname = Console.ReadLine();

                    while (flag)
                    {
                        Console.Write("Lütfen telefon numarasını '0xxx-xxx-xx-xx(0555-555-55-55)' formatına uygun olarak giriniz     :");
                        phonenumber = Console.ReadLine();
                        phoneNumberCheck = Member.PhoneFormatControl(phonenumber);
                        if (phoneNumberCheck == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Telefon numarasını uygun bir formatta girmediniz. Lütfen '0xxx-xxx-xx-xx(0555-555-55-55)' formatına uygun bir telefon numarası giriniz.");
                        }
                    }

                    bool success = Member.AddPerson(name, surname, phonenumber);
                    while (flag)
                    {

                        if (success)
                        {
                            Console.WriteLine("Eklediğiniz kişi rehberinize başarıyla kaydedilmiştir. Lütfen bir seçim yapın:");
                            Member.GetList();
                            Console.WriteLine();
                            Console.WriteLine("--------------");
                            Console.WriteLine("* Ana menüye dönmek için: (6)");
                            Console.WriteLine("* Programdan çıkmak için: (0)");
                            Console.Write("Seçim:");
                            chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                            if (chooseMenu == 0 && chooseMenuCheck)
                            {
                                ExitProgram();
                            }

                            else if (chooseMenu == 6 && chooseMenuCheck)
                            {
                                flag = false;
                            }
                        }

                        else
                        {
                            Console.WriteLine("Kişi rehbere eklenirken bir hata oluştu. Lütfen kayıt işlemini tekrar deneyiniz.");
                            break;
                        }
                    }
                }
                else if (succesChoose && chooseMenu == 2)
                {
                    while (flag)
                    {
                        Console.WriteLine("-------- Varolan Numarayı Silmek --------\n");
                        Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string name = Console.ReadLine();
                        bool checkRemove;
                        char checkLetter;
                        Member person = Member.GetPerson(name);
                        if (person != null)
                        {
                            Console.Write(person.Name + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n): ");
                            checkLetter = char.Parse(Console.ReadLine());
                            if (checkLetter == 'y')
                            {
                                checkRemove = Member.Remove(person);
                                if (checkRemove)
                                {
                                    Member.GetList();
                                    Console.WriteLine("İşlem başarılı bir şekilde gerçekleştirilmiştir.\n");
                                    Console.WriteLine("* Ana menüye dönmek için: (6)");
                                    Console.WriteLine("* Programdan çıkmak için: (0)");
                                    Console.Write("Seçim: ");
                                    chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);
                                    if (chooseMenu == 0 && chooseMenuCheck)
                                    {
                                        ExitProgram();
                                    }
                                    else if (chooseMenu == 6 && chooseMenuCheck)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("İşlem yapılırken bir hata oluştu. Lütfen tekrar deneyin.");
                                    person = null;
                                }
                            }
                            else if (checkLetter == 'n')
                            {
                                Console.Write("Silme işleminden vazgeçtiniz. Lütfen bir seçim yapınız.");
                                Console.WriteLine("* Silmeyi sonlandırıp programdan çıkmak için: (1)");
                                Console.WriteLine("* Yeniden denemek için: (2)");
                                Console.Write("Seçim:");
                                chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);
                                if (chooseMenu == 1 && chooseMenuCheck)
                                {
                                    ExitProgram();
                                }
                                else if (chooseMenu == 2 && chooseMenuCheck)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* İşlemi sonlandırıp programdan çıkmak için: (1)");
                            Console.WriteLine("* Yeniden denemek için: (2)");
                            Console.Write("Seçim:");
                            chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                            if (chooseMenu == 1 && chooseMenuCheck)
                            {
                                ExitProgram();
                            }
                            else if (chooseMenu == 2 && chooseMenuCheck)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (succesChoose && chooseMenu == 3)
                {
                    while (flag)
                    {
                        Console.WriteLine("-------- Varolan Numarayı Güncelleme --------\n");
                        Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string name = Console.ReadLine();
                        Member person = Member.GetPerson(name);
                        Member updatePerson;
                        if (person != null)
                        {
                            Console.WriteLine("Güncellenmek istenen Kişinin Bilgileri:\n");
                            Console.WriteLine("İsim: {0}", person.Name);
                            Console.WriteLine("Soyisim: {0}", person.Surname);
                            Console.WriteLine("Telefon Numarası: {0}", person.PhoneNumber);
                            Console.WriteLine("Güncelleme yapmak istediğiniz kısımları ilgili alanlara yazınız. Güncellemek istemediğiniz alanlara eski verileri tekrar giriniz. Telefon numarası güncellemek isterseniz '0xxx-xxx-xx-xx(0555-555-55-55)' formatına uygun olarak telefon numaranızı giriniz.");
                            Console.Write("İsim: ");
                            string firstname = Console.ReadLine();
                            Console.Write("Soyisim: ");
                            string surname = Console.ReadLine();
                            Console.Write("Telefon Numarası: ");
                            string phone = Console.ReadLine();
                            updatePerson = Member.Update(firstname, surname, phone, person);
                            if (updatePerson != null)
                            {
                                Console.WriteLine("İşlem başarılı bir şekilde gerçekleştirilmiştir.\n");
                                Console.WriteLine("--------------");
                                Member.GetList();
                                Console.WriteLine("* Ana menüye dönmek için: (6)");
                                Console.WriteLine("* Programdan çıkmak için: (0)");
                                Console.Write("Seçim: ");
                                chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);
                                if (chooseMenu == 0 && chooseMenuCheck)
                                {
                                    ExitProgram();
                                }

                                else if (chooseMenu == 6 && chooseMenuCheck)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Güncelleme işlemi yapılırken bir hata oluştu.");
                                Console.WriteLine("* Güncellemeyi sonlandırmak için: (1)");
                                Console.WriteLine("* Yeniden denemek için: (2)");
                                person = null;
                                updatePerson = null;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Güncellemeyi sonlandırmak için için: (1)");
                            Console.WriteLine("* Yeniden denemek için: (2)");
                            Console.Write("Seçim:");
                            chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                            if (chooseMenu == 1 && chooseMenuCheck)
                            {
                                ExitProgram();
                            }

                            else if (chooseMenu == 2 && chooseMenuCheck)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (succesChoose && chooseMenu == 4)
                {
                    Console.WriteLine("-------- Rehberde Listeleme --------\n");
                    Console.WriteLine("Listeleme biçimini seçiniz.");
                    Console.WriteLine("**********************************************\n");
                    Console.WriteLine("****** A-Z için: (1)*****");
                    Console.WriteLine("****** Z-A için: (2)*****\n");
                    Console.Write("Seçim:");
                    int search = 0;
                    bool succesSearchChoose = int.TryParse(Console.ReadLine(), out search);
                    if (search == 1 && succesSearchChoose)
                    {
                        Member.GetListForAlphabet(search);
                    }
                    else if (search == 2 && succesSearchChoose)
                    {
                        Member.GetListForAlphabet(search);
                    }
                }
                else if (succesChoose && chooseMenu == 5)
                {
                    while (flag)
                    {
                        Console.WriteLine("-------- Rehberde Arama Yapmak --------\n");
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                        Console.WriteLine("**********************************************\n");
                        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                        Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)\n");
                        Console.Write("Seçim:");
                        int search = 0;
                        string searchNameorSurname;
                        bool succesSearchChoose = int.TryParse(Console.ReadLine(), out search);
                        if (search == 1 && succesSearchChoose)
                        {
                            Console.Write("Lütfen bulmak istediğiniz ismi ya da soyismi yazınız:");
                            searchNameorSurname = Console.ReadLine();
                            List<Member> personlist = Member.GetListforNameorSurname(searchNameorSurname);
                            if (personlist.Count > 0)
                            {
                                Console.WriteLine("Arama Sonuçlarınız:");
                                Console.WriteLine("**********************************************\n");
                                foreach (var item in personlist)
                                {
                                    Console.WriteLine("İsim: " + item.Name);
                                    Console.WriteLine("Soyisim: " + item.Surname);
                                    Console.WriteLine("Telefon Numarası: " + item.PhoneNumber);
                                    Console.WriteLine("-");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Ana menüye dönmek için 6'ya, çıkmak için 0'a basın: ");
                                chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                                if (chooseMenu == 0 && chooseMenuCheck)
                                {
                                    ExitProgram();
                                }
                                else if (chooseMenu == 6 && chooseMenuCheck)
                                {
                                    flag = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                Console.WriteLine("* Aramayı sonlandırmak için: (1)");
                                Console.WriteLine("* Yeniden denemek için: (2)");
                                chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                                if (chooseMenu == 1 && chooseMenuCheck)
                                {
                                    ExitProgram();
                                }

                                else if (chooseMenu == 2 && chooseMenuCheck)
                                {
                                    flag = true;
                                }
                            }

                        }
                        else if (search == 2 && succesSearchChoose)
                        {

                            while (flag)
                            {
                                Console.Write("Lütfen bulmak istediğiniz telefon numarasını '0xxx-xxx-xx-xx(0555-555-55-55)' formatına uygun olarak giriniz     :");
                                phonenumber = Console.ReadLine();
                                phoneNumberCheck = Member.PhoneFormatControl(phonenumber);
                                if (phoneNumberCheck == true)
                                {
                                    List<Member> personlist = Member.GetListforNumber(phonenumber);
                                    if (personlist.Count > 0)
                                    {
                                        Console.WriteLine("Arama Sonuçlarınız:");
                                        Console.WriteLine("**********************************************\n");
                                        foreach (var item in personlist)
                                        {
                                            Console.WriteLine("İsim: " + item.Name);
                                            Console.WriteLine("Soyisim: " + item.Surname);
                                            Console.WriteLine("Telefon Numarası: " + item.PhoneNumber);
                                            Console.WriteLine("-");
                                        }
                                        Console.WriteLine();
                                        Console.Write("Ana menüye dönmek için 6'ya, çıkmak için 0'a basın: ");
                                        chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                                        if (chooseMenu == 0 && chooseMenuCheck)
                                        {
                                            ExitProgram();
                                        }
                                        else if (chooseMenu == 6 && chooseMenuCheck)
                                        {
                                            flag = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                        Console.WriteLine("* Aramayı sonlandırmak için: (1)");
                                        Console.WriteLine("* Yeniden denemek için: (2)");
                                        chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                                        if (chooseMenu == 1 && chooseMenuCheck)
                                        {
                                            ExitProgram();
                                        }

                                        else if (chooseMenu == 2 && chooseMenuCheck)
                                        {
                                            flag = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Telefon formatını uygun şekilde girmediniz.Lütfen bulmak istediğiniz telefon numarasını '0xxx-xxx-xx-xx(0555-555-55-55)' formatına uygun olarak giriniz     :");
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Aramayı sonlandırmak için: (1)");
                            Console.WriteLine("* Yeniden denemek için: (2)");
                            chooseMenuCheck = int.TryParse(Console.ReadLine(), out chooseMenu);

                            if (chooseMenu == 1 && chooseMenuCheck)
                            {
                                ExitProgram();
                            }

                            else if (chooseMenu == 2 && chooseMenuCheck)
                            {
                                flag = true;
                            }
                        }
                    }
                }
                else if (succesChoose && chooseMenu == 0)
                    ExitProgram();
            }

        }

        private static void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
