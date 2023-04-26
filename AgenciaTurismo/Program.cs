using AgenciaTurismo.Controllers;
using AgenciaTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        //City cities = new()
        //{
        //    Id = 1,
        //    Description = "T"
        //};

        //Address address = new()
        //{
        //    Id = 1,
        //    Street = "g",
        //    Number = 5,
        //    District = "h",
        //    ZipCode = "r",
        //    city = new City() { Id = 1, Description = "xx" },
        //    Complement = "c",
        //};

        //Client client = new Client()
        //{
        //    Id= 1,
        //    Name = "Tiago",
        //    Phone = "123123123",
        //    address = new Address()
        //    {
        //        Id = 1,
        //        Street = "g",
        //        Number = 5,
        //        District = "h",
        //        ZipCode = "r",
        //        city = new City() { Id = 1, Description = "xx" },
        //        Complement = "c",
        //    }
        //};

        //Hotel hotel = new Hotel()
        //{
        //    Id = 1,
        //    Name = "Ibis",
        //    address = new Address()
        //    {
        //        Id = 1,
        //        Street = "J",
        //        Number = 7,
        //        District = "B",
        //        ZipCode = "r",
        //        city = new City() { Id = 1, Description = "GKJ" },
        //        Complement = "c",
        //    },
        //    Price = 250.56M,
        //};

        //Ticket ticket = new()
        //{
        //    Id = 1,
        //    Start = new Address()
        //    {
        //        Id = 1,
        //        Street = "J",
        //        Number = 7,
        //        District = "Kla",
        //        ZipCode = "r",
        //        city = new City() { Id = 1, Description = "GKJç" },
        //        Complement = "c",
        //    },
        //    Destination = new Address()
        //    {
        //        Id = 1,
        //        Street = "R",
        //        Number = 254,
        //        District = "Bairro",
        //        ZipCode = "123142345",
        //        city = new City() { Id = 1, Description = "Sao Carlos" },
        //        Complement = "h",
        //    },
        //    client = new Client()
        //    {
        //        Id = 1,
        //        Name = "Fabio",
        //        Phone = "123123123",
        //        address = new Address()
        //        {
        //            Id = 1,
        //            Street = "g",
        //            Number = 5,
        //            District = "h",
        //            ZipCode = "r",
        //            city = new City() { Id = 1, Description = "xx" },
        //            Complement = "c",
        //        }
        //    },
        //    Price = 546.04M
        //};




        //Packet packet = new()
        //{
        //    Id = 1,
        //    hotel = new Hotel() {
        //        Id = 1,
        //        Name = "Ibis",
        //        address = new Address()
        //        {
        //            Id = 1,
        //            Street = "J",
        //            Number = 7,
        //            District = "B",
        //            ZipCode = "123612637",
        //            city = new City() { Id = 1, Description = "Sao Paulo" },
        //            Complement = "lote 20",
        //        },
        //        Price = (double)250.56,
        //    },
        //    ticket = new Ticket() {
        //        Id = 1,
        //        Start = new Address()
        //        {
        //            Id = 1,
        //            Street = "J",
        //            Number = 7,
        //            District = "Kla",
        //            ZipCode = "r",
        //            city = new City() { Id = 1, Description = "Americo" },
        //            Complement = "c",
        //        },
        //        Destination = new Address()
        //        {
        //            Id = 1,
        //            Street = "R",
        //            Number = 254,
        //            District = "Bairro",
        //            ZipCode = "123142345",
        //            city = new City() { Id = 1, Description = "Sao Carlos" },
        //            Complement = "h",
        //        },
        //        client = new Client()
        //        {
        //            Id = 1,
        //            Name = "Fabio",
        //            Phone = "123123123",
        //            address = new Address()
        //            {
        //                Id = 1,
        //                Street = "g",
        //                Number = 5,
        //                District = "h",
        //                ZipCode = "r",
        //                city = new City() { Id = 1, Description = "Americo" },
        //                Complement = "c",
        //            }
        //        },
        //        Price = 546.04
        //    },
        //    Price = 123.09,
        //    client = new Client() {
        //        Id = 1,
        //        Name = "Tiago",
        //        Phone = "123123123",
        //        address = new Address()
        //        {
        //            Id = 1,
        //            Street = "g",
        //            Number = 5,
        //            District = "h",
        //            ZipCode = "r",
        //            city = new City() { Id = 1, Description = "xx" },
        //            Complement = "c",
        //        }
        //    }

        //var city2 = new City()
        //{
        //    Id = 1,
        //    Description = "Sao Paulo"

        //};
        //City citydapper = new City();

        //new CityController().GetAllDapper().ForEach(x => Console.WriteLine(x));
        //string returninformation = (new CityController().InsertDapper(city2) ? "Registro Inserido" : "Erro");

        //Console.WriteLine(returninformation);

        //Console.WriteLine("Digite o id: ");
        //citydapper.Id = int.Parse(Console.ReadLine());
        //Console.WriteLine("Digite a descrição: ");
        //citydapper.Description = Console.ReadLine();

        //new CityController().UpdateDapper(citydapper);

        //var address = new Address()
        //{
        //    Id = 1,
        //    Street = "AWDawd",
        //    Number = 5,
        //    District = "h",
        //    ZipCode = "r",
        //    city = new City() { Id = 1, Description = "xx" },
        //    Complement = "c",
        //};

        //Address addressdapper = new Address();

        //new AddressController().GetAllDapper().ForEach(x => Console.WriteLine(x));
        //string returninformation1 = (new AddressController().InsertDapper(address) ? "Registro Inserido" : "Erro");

        //Console.WriteLine(returninformation1);
    }
}