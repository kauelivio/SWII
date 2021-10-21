//Kauê de Jesus Livio CB3005461
//Pedro Paulo dos Reis Faria CB3007278
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP01.Command
{
    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }

        public Author()
        {

        }

        public Author(string name, string email, char gender)
        {
            Name = name;
            Email = email;
            Gender = gender;
        }

        public string ToString(Author autor)
        {
            return "Nome: " + autor.Name + ", Email: " + autor.Email + ", Gender: " + autor.Gender.ToString();
        }
    }
}
