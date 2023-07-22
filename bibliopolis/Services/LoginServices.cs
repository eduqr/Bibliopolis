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

        public void GenerateRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    bool superAdminRoleExists = _context.Roles.Any(role => role.Name == "Super Admin");
                    bool librarianExists = _context.Roles.Any(role => role.Name == "Bibliotecario");

                    if (!superAdminRoleExists)
                    {
                        var superAdminRole = new Role
                        {
                            Name = "Super Admin"
                        };

                        _context.Roles.Add(superAdminRole);
                        _context.SaveChanges();
                    }

                    if (!librarianExists)
                    {
                        var bibliotecarioRole = new Role
                        {
                            Name = "Bibliotecario"
                        };

                        _context.Roles.Add(bibliotecarioRole);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GenerateRoles) " + ex.Message);
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
