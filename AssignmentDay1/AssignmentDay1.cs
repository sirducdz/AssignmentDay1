using AssignmentDay1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NashConsole
{
    public enum CarType
    {
        Electric,
        Fuel
    }
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType CarTypee { get; set; }
        public int Menu()
        {
            string menuContent = "1. Add A Car\n2. View All Cars\n3. Search Car By Make\n4. Filter Cars By Type\n5. Remove A Car By Model\n6. Exit\nEnter your choice:";
            Console.WriteLine(menuContent);
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x < 1 || x > 6)
            {
                Console.Write("Not Valid Number! Try Again: ");
            }

            return x;
        }

        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}, Type: {CarTypee}";
        }
    }
    internal class AssignmentDay1
    {
        public List<Car> CarList { get; set; }
        public void Run()
        {
            Car car = new Car();
            int userChoice;
            do
            {
                userChoice = car.Menu();
                switch (userChoice)
                {
                    case 1:
                        AddCar(CarList);
                        break;
                    case 2:
                        ViewAllCars(CarList);
                        break;
                    case 3:
                        SearchCarsByMake(CarList);
                        break;
                    case 4:
                        FilterCarsByType(CarList);
                        break;
                    case 5:
                        RemoveCarsByModel(CarList);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (userChoice != 6);
        }

        public void AddCar(List<Car> carList)
        {
            Car car = new Car();
            Console.WriteLine("Enter Type(Fuel/Electric):\n>");
            car.CarTypee = Validation.GetValidType();
            Console.WriteLine("Enter Make:\n>");
            car.Make = Validation.GetValidString();
            Console.WriteLine("Enter Model:\n>");
            car.Model = Validation.GetValidString();
            Console.WriteLine("Enter Year:\n>");
            car.Year = Validation.GetValidYear();
            carList.Add(car);
            Console.WriteLine("Car added successfully!\n");
        }
        //there is no car to delete 
        //1. carList is empty
        //2. model name is not available in the list
        private void RemoveCarsByModel(List<Car> carList)
        {
            Console.WriteLine("Enter Model To Delete Car(s)");
            string deleteInput = Console.ReadLine();
            int numOfDeletedCar = carList.RemoveAll(car => car.Model.Equals(deleteInput, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"{numOfDeletedCar} Car(s) have deleted\n");
        }

        private void FilterCarsByType(List<Car> carList)
        {
            Console.WriteLine("Enter Type To Filter Car(s):\n>");
            var carType = Validation.GetValidType();
            carList = carList.FindAll(car => car.CarTypee == carType);
            if (carList.Count == 0)
            {
                Console.WriteLine("There Is No Car(s) By Type In The List\n");
            }
            else
            {
                for (int i = 0; i < carList.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {carList[i]}");
                }
                Console.WriteLine();
            }
        }

        private void SearchCarsByMake(List<Car> carList)
        {
            Console.WriteLine("Enter Make To Search Car(s)");
            string makeInput = Console.ReadLine();
            carList = carList.FindAll(car => car.Make.Equals(makeInput, StringComparison.OrdinalIgnoreCase));
            if (carList.Count == 0)
            {
                Console.WriteLine("There Is No Car(s) By Make In The List\n");
            }
            else
            {
                for (int i = 0; i < carList.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {carList[i]}");
                }
                Console.WriteLine();
            }
        }

        private void ViewAllCars(List<Car> carList)
        {
            if (carList.Count == 0)
            {
                Console.WriteLine("There Is No Car(s) By Make In The List\n");
            }
            else
            {
                for (int i = 0; i < carList.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {carList[i]}");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            AssignmentDay1 obj = new AssignmentDay1();
            obj.CarList = new List<Car>();
            obj.Run();
        }

    }

}