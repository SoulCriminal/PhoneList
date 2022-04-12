using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneList
{
    internal class Member
    {
        static List<Member> memberList;

        static Member()
        {
            memberList = new List<Member>
            {
                new Member{ Name="Veronica", Surname="Velazquez", PhoneNumber="0641-272-79-21"},
                new Member{ Name="Jermaine", Surname="Mcintosh", PhoneNumber="0369-638-40-01"},
                new Member{ Name="Kenyon", Surname="Puckett", PhoneNumber="0441-675-38-76"},
                new Member{ Name="Camden", Surname="Bradford", PhoneNumber="0963-275-62-87"},
                new Member{ Name="Curran", Surname="Soto", PhoneNumber="0799-446-05-04"}
            };
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }


        public static bool AddPerson(string name, string surname, string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(name) && (!string.IsNullOrWhiteSpace(surname) && (!string.IsNullOrWhiteSpace(phoneNumber))))
            {
                Member person = new Member();
                person.Name = name;
                person.Surname = surname;
                person.PhoneNumber = phoneNumber;
                memberList.Add(person);
                return true;
            }
            else
                return false;
        }

        public static List<Member> GetAll()
        {
            return memberList;
        }

        public static bool Remove(Member item)
        {
            if (item != null)
            {
                memberList.Remove(item);
                return true;
            }

            else
                return false;

        }

        public static Member Update(string name, string surname, string phonenumber, Member person)
        {
            bool success = PhoneFormatControl(phonenumber);
            if (!string.IsNullOrWhiteSpace(name) && (!string.IsNullOrWhiteSpace(surname) && (!string.IsNullOrWhiteSpace(phonenumber))) && (person != null) && (success))
            {
                person.Name = name;
                person.Surname = surname;
                person.PhoneNumber = phonenumber;
                return person;
            }
            else
                return null;
        }

        public static Member GetPerson(string name)
        {
            foreach (var item in Member.GetAll())
            {
                if (name == item.Name || name == item.Surname)
                    return item;
            }
            return null;

        }

        public static void GetList()
        {
            Console.WriteLine("------- Kişi Listesi -------\n");
            foreach (var item in Member.GetAll())
            {
                Console.WriteLine("İsim: " + item.Name);
                Console.WriteLine("Soyisim: " + item.Surname);
                Console.WriteLine("Numara: " + item.PhoneNumber);
                Console.WriteLine("-");
            }
        }

        public static List<Member> GetListforNameorSurname(string nameorsurname)
        {
            List<Member> personlist = new List<Member>();
            foreach (var item in Member.GetAll())
            {
                if (nameorsurname == item.Name || nameorsurname == item.Surname)
                {
                    personlist.Add(item);
                }
            }
            return personlist;
        }

        public static void GetListForAlphabet(int alphabetType)
        {
            List<Member> sortedList = Member.GetAll().OrderBy(n => n.Name).ToList();

            if (alphabetType == 1)
            {
                foreach (var item in sortedList)
                {
                    Console.WriteLine("İsim:" + item.Name);
                    Console.WriteLine("Soyisim:" + item.Surname);
                    Console.WriteLine("Telefon Numarası:" + item.PhoneNumber);
                    Console.WriteLine("-");
                }
            }
            else if (alphabetType == 2)
            {
                sortedList.Reverse();
                foreach (var item in sortedList)
                {
                    Console.WriteLine("İsim:" + item.Name);
                    Console.WriteLine("Soyisim:" + item.Surname);
                    Console.WriteLine("Telefon Numarası:" + item.PhoneNumber);
                    Console.WriteLine("-");
                }
            }
        }
        public static List<Member> GetListforNumber(string searchPhoneNumber)
        {
            List<Member> personlist = new List<Member>();
            foreach (var item in Member.GetAll())
            {
                if (searchPhoneNumber == item.PhoneNumber)
                {
                    personlist.Add(item);
                }
            }
            return personlist;
        }

        public static bool PhoneFormatControl(string phonenumber)
        {
            string phoneControl = @"^(0(\d{3})-(\d{3})-(\d{2})-(\d{2}))$";
            Match check = Regex.Match(phonenumber, phoneControl, RegexOptions.IgnoreCase);
            return check.Success;
        }
    }
}
