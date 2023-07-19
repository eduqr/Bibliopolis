using bibliopolis.Context;
using bibliopolis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Services
{
    public class LoginServices
    {
        public void GenerateSuperAdmin()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    bool superAdminExists = _context.Librarians.Any(librarian => librarian.Roles.PkRole == 1);

                    if (!superAdminExists)
                    {
                        var superAdmin = new Librarian
                        {
                            Name = "Dominic",
                            Lastname = "Vargas",
                            Mail = "test@gmail.com",
                            PhoneNumber = "123456789",
                            Password = "sa123",
                            FkRole = 1
                        };

                        _context.Librarians.Add(superAdmin);
                        _context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GenerateSA) " + ex.Message);
            }
        }

        public Librarian Login(string mail, string password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var response = _context.Librarians.Include(y => y.Roles).FirstOrDefault(x => x.Mail == mail && x.Password == password);
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (Login) " + ex.Message);
            }
        }
    }
}
