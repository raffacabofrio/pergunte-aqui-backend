﻿using PergunteAqui.Domain;
using PergunteAqui.Domain.Enums;
using System;
using System.Linq;

namespace PergunteAqui.Repository
{
    public class DatabaseInitialSeeder
    {

        private readonly ApplicationDbContext _context;

        // 123456
        private const string PASSWORD_HASH = "n71pJuPLLg4EJkRBf+SRDXHD3x5f1sNI+3Fi5bSjdx4=";
        private const string PASSWORD_SALT = "Uo5G5EKyKh5GnXy0D57i0w==";


        public DatabaseInitialSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                var user1 = new User()
                {
                    Name = "Usuário 01",
                    Email = "user01@transferservice.com",
                    Linkedin = "linkedin.com/walter.cardoso",
                    Password = PASSWORD_HASH,
                    PasswordSalt = PASSWORD_SALT,
                    CreationDate = DateTime.Now,
                    Address = new Address()
                    {
                        Street = "Rua teste",
                        Number = "1",
                        Complement = "apto 1",
                        Neighborhood = "Bairro teste",
                        PostalCode = "11111-111",
                        City = "São Paulo",
                        State = "SP",
                        Country = "Brasil"
                    }
                };

                var user2 = new User()
                {
                    Name = "Usuário 02",
                    Email = "user02@transferservice.com",
                    Linkedin = "linkedin.com/vagner",
                    Profile = Profile.Administrator,
                    Password = PASSWORD_HASH,
                    PasswordSalt = PASSWORD_SALT,
                    CreationDate = DateTime.Now,
                    Address = new Address()
                    {
                        Street = "Rua teste",
                        Number = "2",
                        Complement = "apto 2",
                        Neighborhood = "Bairro teste",
                        PostalCode = "11111-111",
                        City = "São Paulo",
                        State = "SP",
                        Country = "Brasil"
                    }
                };

                var user3 = new User()
                {
                    Name = "Usuário 03",
                    Email = "user03@transferservice.com",
                    Linkedin = "linkedin.com/rodrigo",
                    Password = PASSWORD_HASH,
                    PasswordSalt = PASSWORD_SALT,
                    CreationDate = DateTime.Now,
                    Address = new Address()
                    {
                        Street = "Rua teste",
                        Number = "3",
                        Complement = "apto 3",
                        Neighborhood = "Bairro teste",
                        PostalCode = "11111-111",
                        City = "São Paulo",
                        State = "SP",
                        Country = "Brasil"
                    }
                };

                var user4 = new User()
                {
                    Name = "Usuário 04",
                    Email = "user04@transferservice.com",
                    Linkedin = "linkedin.com/cussa",
                    Profile = Profile.Administrator,
                    Password = PASSWORD_HASH,
                    PasswordSalt = PASSWORD_SALT,
                    CreationDate = DateTime.Now,
                    Address = new Address()
                    {
                        Street = "Rua teste",
                        Number = "4",
                        Complement = "apto 4",
                        Neighborhood = "Bairro teste",
                        PostalCode = "11111-111",
                        City = "São Paulo",
                        State = "SP",
                        Country = "Brasil"
                    }
                };

                _context.Users.AddRange(user1, user2, user3, user4);
                _context.SaveChanges();
            }

        }

    }
}
