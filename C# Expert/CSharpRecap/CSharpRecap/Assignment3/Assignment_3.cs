using System;

namespace CSharpRecap.Assignment3
{

    public class Assignment_3
    {
        public static void Execute()
        {
            Console.WriteLine("==================== Task :  Switch Statement ====================" + Environment.NewLine);


            var rajkot = new City() { Id = 1, Name = "Rajkot", Population = 75 };
            var ahmedabad = new City() { Id = 2, Name = "Ahmedabad", Population = 200 };
            var surat = new City() { Id = 3, Name = "Surat", Population = 0 };
            var mumbai = new City() { Id = 4, Name = "Mumbai"};

            GetMyCityName(ahmedabad);
            GetMyCityName(rajkot);
            GetMyCityName(mumbai);
            GetMyCityName(surat);

            void GetMyCityName(ILocation location)
            {
                switch (location)
                {
                    case City city when city.Population == 0:
                        Console.WriteLine(location.Name + "  ==> Population Data Is Invalid(Zero)");
                        break;
                    case City city when city.Population > 100:
                        Console.WriteLine(location.Name + "  ==> Population is not under control");
                        break;
                    case City city when city.Population < 100:
                        Console.WriteLine(location.Name + "  ==> Population is  under control");
                        break;
                    case City city when city.Population is null:
                        Console.WriteLine(location.Name + "  ==> Population Data Is Invalid(Null)");
                        break;
                    default:
                        Console.WriteLine("Data is Invalid");
                        break;

                }
            }
        }
    }


    public interface ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? Population { get; set; }

    }
    public class City : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Population { get; set; }
        
    }
}
