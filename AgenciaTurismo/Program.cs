using AgenciaTurismo.Controllers;
using AgenciaTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        City cities = new ()
        {
            Id = 1,
            Description = "T"
        };

        Address address = new()
        {
            Id = 1,
            Street = "g",
            Number = 5,
            District = "h",
            ZipCode = "r",
            city = new City() { Id = 1},
            Complement = "c",
        };

        if (new CityController().Insert(cities))
            Console.WriteLine("Registrado com sucesso");
        else
            Console.WriteLine("Erro");

        new CityController().FindAll().ForEach(Console.WriteLine);

        Console.WriteLine("Digite a nova descrição");
        string newdesc = Console.ReadLine();

        new CityController().Update(cities, 1, newdesc);

        if (new addresscontroller().insert(address))
            console.writeline("registrado com sucesso");
        else
            console.writeline("erro");

        new addresscontroller().findall().foreach (console.writeline) ;

        new CityController().Delete(2);
    }
}