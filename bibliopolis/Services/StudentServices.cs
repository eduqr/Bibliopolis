using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.Validations;
using bibliopolis.Views.LibrariansViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bibliopolis.Services
{
    public class StudentServices
    {
        public void AddStudent(Student request) 
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
                    if (_context.Students.Any(x => x.Matricula == request.Matricula))
                    {
                        MessageBox.Show("Ya existe un estudiante con esta matrícula.");
                        return;
                    }

                    Student res = new Student();

                    res.Matricula=request.Matricula;
                    res.Name = request.Name;
                    res.LastName = request.LastName;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Career= request.Career;

                    _context.Students.Add(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (AddStudent)" + ex.Message);
            }
        }
        public void UpdateStudent(Student request)
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
                    Student res = new Student();
                    res = _context.Students.Find(request.Matricula);

                    res.Name = request.Name;
                    res.LastName= request.LastName;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Career = request.Career;

                    _context.Update(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (UpdateStudent)" + ex.Message);
            }
        }
        public void DeleteStudent(string Matricula)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Student res = _context.Students.Find(Matricula);

                    if (InputValidator.IsObjectNull(res))
                    {
                        MessageBox.Show("No se encontró el registro");
                        return;
                    }
                    _context.Students.Remove(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (DeleteLibrarian)" + ex.Message);
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                   
                    List<Student> students = _context.Students.ToList();

                    if (students.Count > 0)
                    {
                        return students;
                    }
                    return students;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetStudents)" + ex.Message);
            }
        }


        


    }
}