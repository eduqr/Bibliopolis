using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bibliopolis.Services
{
    public class BookServices
    {
        public void AddBook(Book request)
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
                    Book res = new Book();

                    res.ISBN = request.ISBN;
                    res.Title = request.Title;
                    res.Author = request.Author;
                    res.Editorial = request.Editorial;
                    res.Units = request.Units;

                    _context.Books.Add(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (AddBook)" + ex.Message);
            }
        }

        public Book ReadBook(Book request)
        {
            try
            {
                if (InputValidator.IsObjectNull(request))
                {
                    MessageBox.Show("Por favor, llene todos los campos");
                    return request;
                }

                using (var _context = new ApplicationDbContext())
                {
                    Book res = _context.Books.Find(request.ISBN);

                    if (res == null)
                        MessageBox.Show("El libro no está registrado");
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (ReadBook)" + ex.Message);
            }
        }

        public void UpdateBook(Book request)
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
                    Book res = _context.Books.Find(request.ISBN);

                    res.ISBN = request.ISBN;
                    res.Title = request.Title;
                    res.Author = request.Author;
                    res.Editorial = request.Editorial;
                    res.Units = request.Units;

                    _context.Books.Update(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (UpdateBook)" + ex.Message);
            }
        }

        public void DeleteBook(Book request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Book res = _context.Books.Find(request.ISBN);
                    if (InputValidator.IsObjectNull(res))
                    {
                        MessageBox.Show("No se encontró el registro");
                        return;
                    }
                    _context.Books.Remove(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (ReadBook)" + ex.Message);
            }
        }
    }
}
