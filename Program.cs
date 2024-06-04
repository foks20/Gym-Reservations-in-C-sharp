// See using System;

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

            Console.WriteLine(GymEquipments.Count());

       

            List<WorkoutCombination> PeopleWorkoutOrder = new List<WorkoutCombination>();
            List<string> Names = new List<string> {
                "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Isaac", "Jack"
            };

           
        
            int max = 100;

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


            for (int i = 0; i < PeopleWorkoutOrder.Count; i++)
            {
                if (!gymReservations.ContainsKey(PeopleWorkoutOrder[i].Machine))
                {
                    gymReservations[PeopleWorkoutOrder[i].Machine] = new Queue<string>();
                }
                else
                {
                    gymReservations[PeopleWorkoutOrder[i].Machine].Enqueue(PeopleWorkoutOrder[i].Name);
                }

                
            }

            Console.WriteLine(gymReservations.Count);


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






