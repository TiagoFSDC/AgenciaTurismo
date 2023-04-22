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

        Address address = new()
        {
            Id = 1,
            Street = "g",
            Number = 5,
            District = "h",
            ZipCode = "r",
            city = new City() { Id = 1, Description = "xx" },
            Complement = "c",
        };

        Client client = new Client()
        {
            Id= 1,
            Name = "Tiago",
            Phone = "123123123",
            address = new Address()
            {
                Id = 1,
                Street = "g",
                Number = 5,
                District = "h",
                ZipCode = "r",
                city = new City() { Id = 1, Description = "xx" },
                Complement = "c",
            }
        };

        Hotel hotel = new Hotel()
        {
            Id = 1,
            Name = "Ibis",
            address = new Address()
            {
                Id = 1,
                Street = "J",
                Number = 7,
                District = "B",
                ZipCode = "r",
                city = new City() { Id = 1, Description = "GKJ" },
                Complement = "c",
            },
            Price = (double)250.56,
        };

        Ticket ticket = new()
        {
            Id = 1,
            Start = new Address()
            {
                Id = 1,
                Street = "J",
                Number = 7,
                District = "Kla",
                ZipCode = "r",
                city = new City() { Id = 1, Description = "GKJç" },
                Complement = "c",
            },
            Destination = new Address()
            {
                Id = 1,
                Street = "R",
                Number = 254,
                District = "Bairro",
                ZipCode = "123142345",
                city = new City() { Id = 1, Description = "Sao Carlos" },
                Complement = "h",
            },
            client = new Client()
            {
                Id = 1,
                Name = "Fabio",
                Phone = "123123123",
                address = new Address()
                {
                    Id = 1,
                    Street = "g",
                    Number = 5,
                    District = "h",
                    ZipCode = "r",
                    city = new City() { Id = 1, Description = "xx" },
                    Complement = "c",
                }
            },
            Price = 546.04
        };

        //if (new CityController().Insert(cities))
        //    Console.WriteLine("Registrado com sucesso");
        //else
        //    Console.WriteLine("Erro");

        //new CityController().FindAll().ForEach(Console.WriteLine);

        //Console.WriteLine("Digite a nova descrição");
        //string newdesc = Console.ReadLine();

        //new CityController().Update(cities, 1, newdesc);

        //if (new AddressController().Insert(address) != null)
        //    Console.WriteLine("registrado com sucesso");
        //else
        //    Console.WriteLine("erro");

        new AddressController().FindAll().ForEach(Console.WriteLine);

        //new CityController().Delete(2);

        //Console.WriteLine("Digite o novo logradouro: ");
        //string logradouro = Console.ReadLine();

        //new AddressController().Update(address, 1, logradouro);
        //new AddressController().Delete(2);

        //if (new ClientController().Insert(client))
        //    Console.WriteLine("Sucesso");

        //new ClientController().FindAll().ForEach(x => Console.WriteLine(x));

        //new ClientController().Update(2, "Vinicius");
        //new ClientController().Delete(3);

        //if (new HotelController().Insert(hotel))
        //   Console.WriteLine("Sucesso");

        //new HotelController().Update(1, "Travel");
        //new HotelController().Delete(1);

        //if (new TicketController().Insert(ticket))
        //   Console.WriteLine("Sucesso");

        //new TicketController().Update(1, 456.00);
        //new TicketController().Delete(1);

        //var city2 = new City()
        //{
        //    Id = 1,
        //    Description = "adwa"

        //};

        //string returninformation = (new CityController().InsertDapper(city2) ? "Registro Inserido" : "Erro");

        //Console.WriteLine(returninformation);

        //new CityController().GetAllDapper().ForEach(x => Console.WriteLine(x));

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
        //};
        //if (new PacketController().Insert(packet))
        //    Console.WriteLine("Sucesso");
    }
}