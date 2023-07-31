using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.UserControls;
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
    public class LoanServices
    {
        public void AddLoan(Loan request)
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
                    Loan res = new Loan();
                    res.RegistrationNumber = request.RegistrationNumber;
                    res.ISBN = request.ISBN;
                    res.LoanDate = request.LoanDate;
                    res.DueDate = request.DueDate;
                    res.Status = request.Status;
                    
                    _context.Loans.Add(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error (AddLoan)" + ex.Message);
            }
        }

        public void UpdateStatusLoan(Loan request)
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
                    Loan res = _context.Loans.Find(request.PkLoan);

                    res.Status = request.Status;

                    _context.Loans.Update(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (UpdateLoan)" + ex.Message);
            }
        }

        public void DeleteLoan(int searchedPkLoan)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Loan res = _context.Loans.Find(searchedPkLoan);
                    if (InputValidator.IsObjectNull(res))
                    {
                        MessageBox.Show("No se encontró el registro");
                        return;
                    }
                    _context.Loans.Remove(res);
                    _context.SaveChanges();
                    MessageBox.Show("Préstamo eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (DeleteLoan)" + ex.Message);
            }
        }

        public List<Loan> GetLoans()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    List<Loan> loan = _context.Loans.ToList();

                    if (loan.Count > 0)
                    {
                        return loan;
                    }
                    return loan;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetLoans)" + ex.Message);
            }
        }

    }
}
