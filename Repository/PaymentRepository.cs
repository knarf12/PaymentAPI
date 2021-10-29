using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        PaymentDetailContext _context;

        public PaymentRepository(PaymentDetailContext paymentDetailContext) 
        {
            _context = paymentDetailContext;
        }
        public void DeletePaymentDetail(int id)
        {
            PaymentDetail paymentDetail = _context.PaymentDetails.Find(id);
            _context.PaymentDetails.Remove(paymentDetail);
        }

        public PaymentDetail GetPaymentDetailById(int id)
        {
            return _context.PaymentDetails.Find(id);
        }

        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
            return _context.PaymentDetails;
        }

        public void InsertPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePaymentDetail(PaymentDetail paymentDetail)
        {
            _context.Entry(paymentDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
