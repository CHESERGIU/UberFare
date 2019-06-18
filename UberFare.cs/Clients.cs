using System;

namespace UberFare
{
    public class Client
    {
        private readonly string name;        
        internal readonly int Travels;

        public Client(string Name, int Travels = 0)
        {
            this.name = Name;
            this.Travels = Travels;
        }

        public static Client[] GetClients(string Name, int Travels = 0)
        {
            return GetClients(Name, Travels);
        }

        public static bool Fidelity20(int Travels) => Travels >= 20 ? true : false;

        public static bool Fidelity10(int Travels) => Travels >= 10 && Travels < 20 ? true : false;

        internal static decimal GetLength(Client[] passenger)
        {
            return passenger.Length;
        }
    }
}