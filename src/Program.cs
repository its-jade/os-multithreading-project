class Program {

    static void Main() {

        Simulations simulation = new Simulations();
        Boolean isRunning = true;

        while (isRunning) {

            Console.WriteLine("Select a simulation: \n1. Race Condition\n2. Resolved Race Condition\n3. Deadlock\n4. Resolved Deadlock\n5. Multiple Customers\n6. Quit");
            string selection = Console.ReadLine() ?? string.Empty;

            switch (selection) {
                case "1":
                    Console.WriteLine("\nRace Condition Simulation");
                    simulation.RaceCondition();
                    break;

                case "2":
                    Console.WriteLine("\nResolved Race Condition Simulation");
                    simulation.ResolvedRaceCondition();
                    break;

                case "3":
                    Console.WriteLine("\nDeadlock Simulation");
                    simulation.Deadlock();
                    break;

                case "4":
                    Console.WriteLine("\nResolved Deadlock Simulation");
                    simulation.ResolvedDeadlock();
                    break;

                case "5":
                    Console.WriteLine("\nMultiple Customers Simulation");
                    simulation.SimulateMultipleCustomers();
                    break;

                case "6":
                    Console.WriteLine("\nExiting Multi-threaded Program");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid selection, please try again");
                    break;
            }
        }
    }
}
