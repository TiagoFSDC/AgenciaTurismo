using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Address
    {
        //public readonly static string INSERT = @"insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade)
        //                                            values (@Street, @Number, @District, @ZipCode, @Complement, @City)";

        public readonly static string INSERT1 = @"insert into Endereco (e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, e.IdCidade)
                                                    select @Street, @Number, @District, @ZipCode, @Complement, c.Id 
                                                    from Endereco e INNER JOIN Cidade c ON e.IdCidade = c.Id";

        public readonly static string GETALL = @"select e.Id,e.Logradouro as Street,e.Numero as Number, e.Bairro as District, e.CEP as ZipCode, e.Complemento as Complement, 
                                                  e.Dtcadastro as RegisterDate, c.Id, c.Descricao, c.Dtcadastro
                                                 from Endereco e Join Cidade c ON c.Id = e.IdCidade";

        public readonly static string UPDATE = @"update Endereco Set Logradouro = @Street where Id = @Id";
        public readonly static string DELETE = @"Delete from Endereco where Id = @Id";


        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public City city { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            return $"\n\nId: {Id}\nLogradouro: {Street}\nNumero: {Number}\nBairro: {District}\nCEP: {ZipCode}" +
                $"\nComplemento: {Complement}\nData: {RegisterDate}\nCidade: {city}";
        }
    }
}
