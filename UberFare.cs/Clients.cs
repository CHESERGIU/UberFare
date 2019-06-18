namespace UberFare
{
    public class Clients
    {
        private readonly string name;        
        internal readonly int Travels;
        internal readonly int Riders;

        public Clients(string Name, int Riders, int Travels)
        {
            this.name = Name;
            this.Riders = Riders;
            this.Travels = Travels;
        }

        public static bool Fidelity20(int Travels) => Travels >= 20 ? true : false;

        public static bool Fidelity10(int Travels) => Travels >= 10 && Travels < 20 ? true : false;

    }
}