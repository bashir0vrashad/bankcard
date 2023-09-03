
using ConsoleApp1;
using Microsoft.VisualBasic;
using System;

BankCard card1 = new BankCard("Kapital", "Kapital Bank", "2001", 670);
BankCard card2 = new BankCard("Kapital", "Kapital Bank", "1972", 450);
BankCard card3 = new BankCard("Kapital", "Kapital Bank", "1976", 341);
BankCard card4 = new BankCard("Kapital", "Kapital Bank", "2002", 567);
BankCard card5 = new BankCard("Kapital", "Kapital Bank", "2004", 890);


Client c1 = new Client("Rashad", "Bashirov", 22, 5000, card1);
Client c2 = new Client("Mahammad", "Bashirov", 51, 5000, card2);
Client c3 = new Client("Tamara", "Bashirova", 47, 5000, card3);
Client c4 = new Client("Elmar", "Bashirov", 21, 5000, card4);
Client c5 = new Client("Rauf", "Bashirov", 19, 5000, card5);

Bank b1 = new Bank();
b1.Clients.Add(c1);
b1.Clients.Add(c2);
b1.Clients.Add(c3);
b1.Clients.Add(c4);
b1.Clients.Add(c5);

string[] menyu1 = { "ADMIN", "USER", "EXIT" };
string[] menyu2 = { "       BALANCE", "        CASH", "  RECENT OPERATIONS", "CARD TO CARD TRANSFER" };
string[] menyu3 = { "MANAT", "DOLLARS", "EURO", "RUB" };
string[] menyu4 = { "10 ", "20 ", "50 ", "100 ", "OTHER " };
string[] menyu6 = { "         CREATE USER", "          USER LIST", "TRANSACTIONS COMPLETED BY USERS", "     ALL USER INFORMATION" };


static void show(string[] menyu, int a)
{
    for (int i = 0; i < menyu.Length; i++)
    {
        if (a == i) Console.ForegroundColor = ConsoleColor.DarkYellow;
        else Console.ResetColor();
        Console.WriteLine(menyu[i]);
    }
}


static int menyu(string[] arry)
{
    int a = 0;
    while (true)
    {
        Console.Clear();
        show(arry, a);
        var secim = Console.ReadKey();
        if (secim.Key == ConsoleKey.DownArrow)
        {
            if (a == arry.Length - 1) a = 0;
            else a++;
        }
        else if (secim.Key == ConsoleKey.UpArrow)
        {
            if (a == 0) a = arry.Length - 1;
            else a--;
        }
        if (secim.Key == ConsoleKey.Enter)
        {
            Console.ResetColor();
            return a;
        }

    }


}



int secme1;
int secme2;
int secme3;
int secme4;
int secme6;
bool yoxlanis1;
int sehv_giris = 0;
int client_index = 0;

while (true)
{
    yoxlanis1 = false;
    secme1 = menyu(menyu1);
    if (secme1 == 1)
    {
        string pin;
        Console.Clear();
        Console.Write("ENTER YOUR PIN: ");
        pin = Console.ReadLine();
        for (int i = 0; i < b1.Clients.Count; i++)
        {
            if (b1.Clients[i].BankAccount.PIN == pin)
            {
                client_index = i;
                Console.Clear();
                Console.WriteLine($"WELCOME {b1.Clients[i].Name} {b1.Clients[i].Surname} ,WELCOME PLEASE CHOOSE ONE BELOW: ");
                Thread.Sleep(2000);
                yoxlanis1 = true;
                secme2 = menyu(menyu2);
                Console.Clear();
                if (secme2 == 0)
                {
                    Console.WriteLine($"MONEY IN YOUR ACCOUNT: {b1.Clients[i].BankAccount.Balans}");
                    b1.Clients[i].zaman.Add(DateTime.Now);
                    b1.Clients[i].emeliyyatlar.Add("BALANCE CHECK");
                    Thread.Sleep(4000);
                }
                else if (secme2 == 1)
                {
                    Console.Clear();
                    Console.WriteLine("SELECT RATE TYPE: ");
                    secme3 = menyu(menyu3);
                    Console.Clear();
                    Console.WriteLine("ENTER THE AMOUNT YOU WANT TO WITHDRAW: ");
                    Thread.Sleep(1000);
                    secme4 = menyu(menyu4);
                    decimal mexaric = 10;

                    if (secme4 == 1) mexaric *= 2;
                    else if (secme4 == 2) mexaric *= 5;
                    else if (secme4 == 3) mexaric *= 10;
                    else if (secme4 == 4)
                    {
                        Console.WriteLine("ENTER THE AMOUNT YOU WANT TO WITHDRAW:: ");
                        string m = Console.ReadLine();
                        mexaric = (decimal)int.Parse(m);
                    }
                    if (secme3 == 0)
                    {
                        if (b1.Clients[i].BankAccount.Balans - mexaric > 0) b1.Clients[i].BankAccount.Balans -= mexaric;
                        else throw new ApplicationException("THERE WASN'T AS MUCH MONEY AS YOU WANT IN THE AMOUNT.");

                        b1.Clients[i].emeliyyatlar.Add($"EXPENSED: {mexaric} MANAT");
                    }
                    if (secme3 == 1)
                    {
                        if (b1.Clients[i].BankAccount.Balans - mexaric * 1.7M > 0) b1.Clients[i].BankAccount.Balans -= mexaric * 1.7M;
                        else throw new ApplicationException("THERE WASN'T AS MUCH MONEY AS YOU WANT IN THE AMOUNT.");

                        b1.Clients[i].emeliyyatlar.Add($"EXPENSED: {mexaric} DOLLARS");
                    }
                    if (secme3 == 2)
                    {
                        if (b1.Clients[i].BankAccount.Balans - mexaric * 2 > 0) b1.Clients[i].BankAccount.Balans -= mexaric * 2;
                        else throw new ApplicationException("THERE WASN'T AS MUCH MONEY AS YOU WANT IN THE AMOUNT.");

                        b1.Clients[i].emeliyyatlar.Add($"EXPENSED: {mexaric} EURO");
                    }
                    if (secme3 == 3)
                    {
                        if (b1.Clients[i].BankAccount.Balans - mexaric / 57 > 0) b1.Clients[i].BankAccount.Balans -= mexaric / 57;
                        else throw new ApplicationException("THERE WASN'T AS MUCH MONEY AS YOU WANT IN THE AMOUNT.");

                        b1.Clients[i].emeliyyatlar.Add($"EXPENSED: {mexaric} RUB");
                    }
                    b1.Clients[i].zaman.Add(DateTime.Now);





                }
                else if (secme2 == 2)
                {
                    string[] menyu5 = new string[b1.Clients[client_index].zaman.Count];
                    for (int l = 0; l < b1.Clients[client_index].zaman.Count; l++)
                    {
                        menyu5[l] = b1.Clients[client_index].zaman[l].ToString();
                    }
                    int secme5 = menyu(menyu5);
                    Console.WriteLine(b1.Clients[client_index].emeliyyatlar[secme5]);
                    Thread.Sleep(2000);
                }
                else if (secme2 == 3)
                {
                    Console.Clear();
                    string kocurme;
                    bool yoxla;
                    int sehv_say = 0;
                    while (true)
                    {
                        yoxla = false;
                        Console.WriteLine("ENTER ANOTHER CARD PIN: ");
                        kocurme = Console.ReadLine();
                        if (kocurme == b1.Clients[client_index].BankAccount.PIN) throw new ApplicationException("ANOTHER CARD PIN MUST BE ENTERED.");

                        for (int k = 0; k < b1.Clients.Count; k++)
                        {
                            if (b1.Clients[k].BankAccount.PIN == kocurme)
                            {
                                Console.Clear();
                                Console.WriteLine("ENTER AMOUNT FOR TRANSFER(TRANSFER IS POSSIBLE FOR ONLY MANAT): ");
                                string kart_mebleg = Console.ReadLine();
                                if ((decimal)int.Parse(kart_mebleg) > b1.Clients[client_index].BankAccount.Balans) throw new ApplicationException($"YOU DO NOT HAVE {kart_mebleg} MANAT IN YOUR BALANCE...");
                                b1.Clients[k].BankAccount.Balans += (decimal)int.Parse(kart_mebleg);
                                b1.Clients[client_index].BankAccount.Balans -= (decimal)int.Parse(kart_mebleg);
                                b1.Clients[client_index].zaman.Add(DateTime.Now);
                                b1.Clients[client_index].emeliyyatlar.Add($"CARD TO CARD TRANSFER --- {kart_mebleg} MANAT WAS SENT TO THE CLIENT NAMED {b1.Clients[k].Name[0]}***{b1.Clients[k].Name[b1.Clients[k].Name.Length - 1]} {b1.Clients[k].Surname[0]}***{b1.Clients[k].Surname[b1.Clients[k].Surname.Length - 1]}");
                                yoxla = true;
                                break;
                            }
                        }
                        if (!yoxla)
                        {
                            sehv_say++;
                            if (sehv_say == 3) throw new ApplicationException("CARD TO CARD TRANSFER YOU ENTERED THE WRONG PIN CODE 3 TIMES ERROR...");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("WAIT 3 SECONDS. YOU ARE RETURNED TO THE MAIN MENU...");
                            Thread.Sleep(3000);
                            break;
                        }
                    }


                }

            }
        }
        if (!yoxlanis1)
        {
            Console.WriteLine("WRONG PIN...");
            Thread.Sleep(1500);
            sehv_giris++;
            if (sehv_giris == 3)
            {
                throw new ApplicationException("YOU ENTERED WRONG 3 TIMES ERROR...");

            }

        }

    }
    else if (secme1 == 0)
    {
        secme6 = menyu(menyu6);
        if (secme6 == 0)
        {
            string yeni_ad, yeni_soyad, yeni_pin;
            float yeni_maas;
            int yeni_yas;
            Console.Clear();
            Console.WriteLine("ENTER NEW USER NAME: ");
            yeni_ad = Console.ReadLine();
            Console.WriteLine("ENTER NEW USER LAST NAME: ");
            yeni_soyad = Console.ReadLine();
            Console.WriteLine("ENTER NEW USER AGE: ");
            yeni_yas = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER NEW USER SALARY: ");
            yeni_maas = float.Parse(Console.ReadLine());
            Console.WriteLine("ENTER NEW USER PİN: ");
            yeni_pin = Console.ReadLine();
            bool y;
            while (true)
            {
                y = false;
                decimal yeni_balans = 0;
                BankCard yeni_kart = new BankCard(b1.Clients[0].BankAccount.BankName, b1.Clients[0].BankAccount.FullName, yeni_pin, yeni_balans);
                for (int i = 0; i < b1.Clients.Count; i++)
                {
                    if (b1.Clients[i].BankAccount.PAN == yeni_kart.PAN)
                    {
                        y = true;
                        break;
                    }
                }
                if (!y)
                {
                    Client yeni = new Client(yeni_ad, yeni_soyad, yeni_yas, yeni_maas, yeni_kart);
                    b1.Clients.Add(yeni);
                    Console.WriteLine("NEW USER CREATED...");
                    Thread.Sleep(1500);
                    break;
                }
            }
        }
        else if (secme6 == 1)
        {
            Console.Clear();
            for (int i = 0; i < b1.Clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {b1.Clients[i].Name}  {b1.Clients[i].Surname}");
            }
            Thread.Sleep(3000);
        }
        else if (secme6 == 2)
        {
            Console.Clear();
            for (int i = 0; i < b1.Clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {b1.Clients[i].Name}  {b1.Clients[i].Surname}\n");
                for (int u = 0; u < b1.Clients[i].emeliyyatlar.Count; u++)
                {
                    Console.WriteLine($"{b1.Clients[i].emeliyyatlar[u]} -- {b1.Clients[i].zaman[u].ToString()}");
                }
                Console.WriteLine("------------------------------");
            }
            Thread.Sleep(10000);
        }
        else if (secme6 == 3)
        {
            Console.Clear();
            for (int i = 0; i < b1.Clients.Count; i++)
            {

                Console.WriteLine($"{i + 1}) {b1.Clients[i].Name}  {b1.Clients[i].Surname}\n" +
                    $"İD: {b1.Clients[i].Id.ToString()}\n" +
                    $"AGE: {b1.Clients[i].Age}\n" +
                    $"SALARY: {b1.Clients[i].Salary}\n" +
                    $"PAN: {b1.Clients[i].BankAccount.PAN}\n" +
                    $"PİN: {b1.Clients[i].BankAccount.PIN}\n" +
                    $"CVC: {b1.Clients[i].BankAccount.CVC}\n" +
                    $"BALANCE: {b1.Clients[i].BankAccount.Balans}\n" +
                    $"DATE: {b1.Clients[i].BankAccount.ExpireDate.ToString()}\n ");
                Console.WriteLine("------------------------------");
            }
            Thread.Sleep(10000);
            Console.Clear();
        }
    }
    else if (secme1 == 2) break;



}

