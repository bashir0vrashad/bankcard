
namespace ConsoleApp1
{
  
    public class BankCard
    {
        private string bank_name;
        private string full_name;
        private string pan;
        private string pin;
        private string cvc;
        private DateTime expiredate;
        private decimal balans;
        public string BankName
        {
            get { return bank_name; }
            set
            {
                bank_name = (value.Length >= 3) ?  value : throw new ApplicationException("Bank Name ERROR...");
            }
        }
       
        public string FullName
        {
            get { return full_name; }
            set
            {
                full_name = (value.Length >= 3) ? value : throw new ApplicationException("Full Name ERROR...");
            }
        }
        public string PAN
        {
            get { return pan; }
            set
            {
                if (value.Length == 16)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (!((int)value[i] >= 48 && (int)value[i] <= 57)) throw new ApplicationException("PAN should only consist of numbers ERROR...");
                    }
                    pan = value;
                }
                else throw new ApplicationException("PAN should be 16 digits ERROR...");

            }
        }
        public string PIN
        {
            get { return pin; }
            set
            {
                if (value.Length == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (!((int)value[i] >= 48 && (int)value[i] <= 57)) throw new ApplicationException("PIN should only consist of numbers ERROR...");
                    }
                    pin = value;
                }
                else throw new ApplicationException("PIN should be 4 digits ERROR...");

            }
        }

        public string CVC
        {
            get { return cvc; }
            set { 

                if (value.Length == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!((int)value[i] >= 48 && (int)value[i] <= 57)) throw new ApplicationException("CVC should only consist of numbers ERROR...");
                    }
                    cvc = value;
                }
                else throw new ApplicationException("CVC should be 3 digits ERROR...");

            }
        }

        public DateTime ExpireDate { get; set; }
      
        public decimal Balans { get;set;}


      public  BankCard()
        {
            BankName = "NULL";

            FullName = "NULL";

            Random a = new Random();
            double b = a.NextDouble();
            if (b > 0.001 && b <= 0.1) b *= 100000000000000000;
            else if (b > 0 && b < 1) b *= 10000000000000000;
           
            b = Math.Floor(b);
            PAN = b.ToString();

            PIN = "0000";

            CVC = Convert.ToString(Random.Shared.Next(100, 1000));

            ExpireDate = DateTime.Now;

             Balans = 0;
        }
       public BankCard(string name1, string name2 ,  string pin , decimal balans) : this() 
        { 
            BankName= name1;
            FullName = name2;
            //PAN = pan;
            PIN = pin;
            Balans = balans;
        }
       

    }
}