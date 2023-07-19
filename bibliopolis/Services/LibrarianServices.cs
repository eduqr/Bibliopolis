using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bibliopolis.Services
{
    public class LibrarianServices
    {
        public void AddLibrarian(Librarian request)
        {
			try
			{
				if (InputValidator.IsObjectNull(request))
				{
                    MessageBox.Show("Por favor, llene todos los campos");
					return;
                }

                using (var _context = new ApplicationDbContext())
                {
                    Librarian res = new Librarian();
                    
                    res.Name = request.Name;
                    res.Lastname = request.Lastname;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Password = request.Password;
                    res.FkRole = request.FkRole;

                    _context.Librarians.Add(res);
                    _context.SaveChanges();
                }
            }
			catch (Exception ex)
			{
				throw new Exception("Sucedió un error (AddLibrarian)" + ex.Message);
			}
        }

        public void UptadeLibrarian(Librarian request)
        {
            try
            {
                if (InputValidator.IsObjectNull(request))
                {
                    MessageBox.Show("Por favor, llene todos los campos");
                    return;
                }

                using (var _context = new ApplicationDbContext())
                {
                    Librarian res = new Librarian();
                    res = _context.Librarians.Find(request.PkLibrarian);

                    res.Name = request.Name;
                    res.Lastname = request.Lastname;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Password = request.Password;
                    res.FkRole = request.FkRole;

                    _context.Update(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (UpdateLibrarian)" + ex.Message);
            }
        }

        public void DeleteLibraian(int pkLibrarian)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Librarian res = _context.Librarians.Find(pkLibrarian);
                    if (InputValidator.IsObjectNull(res))
                    {
                        MessageBox.Show("No se encontró el registro");
                        return;
                    }
                    _context.Librarians.Remove(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (DeleteLibrarian)" + ex.Message);
            }
        }

        public List<Librarian> GetLibrarians()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Librarian> librarians = _context.Librarians.Include(x => x.Roles).ToList();
                    if (librarians.Count > 0)
                    {
                        return librarians;
                    }
                    return librarians;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetLibrarians)" + ex.Message);
            }
        }

        public List<Role> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Role> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetRoles)" + ex.Message);
            }
        }
    }
}
