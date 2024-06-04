// See using System;

using System.Globalization;
using System.Reflection.PortableExecutable;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Queue<string>> gymReservations = new Dictionary<string, Queue<string>>();
            
            List<string> GymEquipments = new List<string>();

            GymEquipments.Add("Bench Press");
            GymEquipments.Add("Shoulder Press");
            GymEquipments.Add("Leg Press");
            GymEquipments.Add("Arm Press");
            GymEquipments.Add("Neck Press");
            GymEquipments.Add("Feet Press");       

            List<WorkoutCombination> PeopleWorkoutOrder = new List<WorkoutCombination>();

            List<string> Names = new List<string> {
                "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Isaac", "Jack"
            };
                    

            for(int i = 100; i >=0; i--)
            {
                Random randomCombination = new Random();

                int randomIndexName = randomCombination.Next(Names.Count);
                int randomMachineName = randomCombination.Next(GymEquipments.Count);

                string randomName = Names[randomIndexName];
                string randomMachine = GymEquipments[randomMachineName];

                WorkoutCombination combination = new WorkoutCombination(randomName, randomMachine);
                PeopleWorkoutOrder.Add(combination);
            }

            int time = 100;

            for (int i = 0; i < PeopleWorkoutOrder.Count; i++)
            {
                if (!gymReservations.ContainsKey(PeopleWorkoutOrder[i].Machine))
                {
                    gymReservations[PeopleWorkoutOrder[i].Machine] = new Queue<string>();
                }
                else
                {
                    gymReservations[PeopleWorkoutOrder[i].Machine].Enqueue(PeopleWorkoutOrder[i].Name);
                    time -= 25;
                }

                if (time == 0)
                {
                    time = 100;
                    foreach (string machine in gymReservations.Keys)
                    {
                        if (gymReservations[machine].Count > 0)
                        {
                            string name = gymReservations[machine].Dequeue();
                            Console.WriteLine($"{name} finished using {machine}");
                        }
                    }
                }
            }

            foreach(string machine in gymReservations.Keys)
            {
                Console.WriteLine(machine);

                // Check if there's anyone in the queue
                if (gymReservations[machine].Count > 0)
                {
                    // Print each person in the queue
                    foreach (string name in gymReservations[machine])
                    {
                        Console.WriteLine($"\t- {name}");
                    }
                }
            }
        }

        class WorkoutCombination
        {
            public string Name { get; set; }
            public string Machine { get; set; }

            public WorkoutCombination(string name, string machine)
            {
                this.Name = name;
                this.Machine = machine;
            }


        }
    }
}






