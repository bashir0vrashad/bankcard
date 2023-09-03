namespace ConsoleApp1
{
    internal class Client
    {

        private Guid id;
        private string name;
        private string surname;
        private int age;
        private float salary;
        private BankCard bankAccount;
      public  List<DateTime> zaman = new List<DateTime>();
      public  List<string> emeliyyatlar = new List<string>();
        public Guid Id { get; set; }
        public string Name {
            get { return name; }
            set
            {
                if (value.Length >= 3) name = value;
                else throw new ApplicationException("Clieant Name ERROR...");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Length >= 4) surname = value;
                else throw new ApplicationException("Clieant Surname ERROR...");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18) age = value;
                else throw new ApplicationException("Clieant Age ERROR...");
            }
        }

        public float Salary
        {
            get { return salary; }
            set
            {
                if (value >= 250) salary = value;
                else throw new ApplicationException("Clieant Salary ERROR...");
            }
        }

        public BankCard BankAccount { get; set; }


      

       public Client()
        {   Id= Guid.NewGuid();
            Name = "NULL";
            Surname = "NULL";
            Age = 18;
            Salary = 250;
            BankAccount = null;
        }

        public Client(string name , string surname , int age , float salary , BankCard b):this() 
        {
            Name = name;
            Surname =surname;
            Age = age;
            Salary = salary;
            BankAccount = b;
        }




    }
}
