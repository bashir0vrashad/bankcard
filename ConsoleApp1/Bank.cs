namespace ConsoleApp1
{
    internal class Bank
    {
        private List<Client> clients;
        public List<Client> Clients { get; set; }
        public Bank() {
            Clients = new List<Client>();
        }
        public Bank(List<Client> other)  { Clients = other; }

        
         
    }
}
