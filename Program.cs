namespace OkeyFilter
{
    class Table
    {
        public int Bahis { get; set; }
        public int Id { get; set; }
        public bool Hizli { get; set; }
        public bool TekeTek { get; set; }
        public bool Rovansli { get; set; }
    }

    class Program
    {
        static public int numberOfTable = 100;

        private static void Main()
        {
            // List of existing tables.
            List<Table> tables = new List<Table>();

            for (int i = 0; i < numberOfTable; i++)
            {
                var random = new Random();
                int bahis = random.Next(200, 5000);
                bool isHizli = random.NextDouble() >= 0.5;
                bool isTeketek = random.NextDouble() >= 0.5;
                bool isRovansli = random.NextDouble() >= 0.5;

                Table table = new Table { Id = i, Bahis = bahis, Hizli = isHizli, TekeTek = isTeketek, Rovansli = isRovansli };
                tables.Add(table);

                // Console.WriteLine("Id: {0} Bahis: {1} Hızlı: {2} Teke Tek: {3} Rövanşlı: {4}", table.Id, table.Bahis, table.Hizli, table.TekeTek, table.Rovansli);
            }

            Console.WriteLine("Min bahis araliği [200$-5000$]");
            int minBet = Convert.ToInt32(Console.ReadLine());

            if (minBet < 200)
            {
                Console.WriteLine("Min bahis araligi 200'den kucuk olamaz!");
                Environment.Exit(0);
            }

            Console.WriteLine("Max bahis araligi [200$-5000$]");
            int maxBet = Convert.ToInt32(Console.ReadLine());

            if (maxBet > 5000)
            {
                Console.WriteLine("Max bahis araligi 5000'den buyuk olamaz!");
                Environment.Exit(0);
            }

            if (maxBet < minBet)
            {
                Console.WriteLine("Max bahis araligi, min bahis araligindan kucuk olamaz!");
                Environment.Exit(0);
            }

            Console.Write("Hizli masa istiyor musunuz? (e/h): ");
            string hizli = Console.ReadLine().ToLower();

            Console.Write("Teke Tek masa istiyor musunuz? (e/h): ");
            string tekeTek = Console.ReadLine().ToLower();

            Console.Write("Rövansli masa istiyor musunuz? (e/h): ");
            string rovansli = Console.ReadLine().ToLower();

            // Suitable tables' list for player.
            List<Table> suitableTables = new List<Table>();

            foreach (Table table in tables)
            {
                if (minBet < table.Bahis && maxBet > table.Bahis)
                {
                    switch (hizli.ToLower())
                    {
                        case "h":
                            if (table.Hizli == true)
                                continue;
                            break;
                        case "e":
                            if (table.Hizli == false)
                                continue;
                            break;
                    }

                    switch (tekeTek.ToLower())
                    {
                        case "h":
                            if (table.TekeTek == true)
                                continue;
                            break;
                        case "e":
                            if (table.TekeTek == false)
                                continue;
                            break;
                    }

                    switch (rovansli.ToLower())
                    {
                        case "h":
                            if (table.Rovansli == true)
                                continue;
                            break;
                        case "e":
                            if (table.Rovansli == false)
                                continue;
                            break;
                    }

                    suitableTables.Add(table);
                }
            }
            foreach (Table table in suitableTables)
            {
                Console.WriteLine("Id: {0} Bahis: {1} Hizli: {2} Teke Tek: {3} Rövansli: {4}", table.Id, table.Bahis, table.Hizli, table.TekeTek, table.Rovansli);
            }

            int sayac = suitableTables.Count();
            if (sayac == 0)
            {
                Console.WriteLine("Filtrenize uygun masa bulunmamaktadir.");
                Environment.Exit(0);
            }
        }
    }
}