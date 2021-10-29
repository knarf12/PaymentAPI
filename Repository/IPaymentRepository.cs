using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    interface IPaymentRepository
    {
        IEnumerable<PaymentDetail> GetPaymentDetails();
        PaymentDetail GetPaymentDetailById(int id);
        void InsertPaymentDetail(PaymentDetail paymentDetail);
        void DeletePaymentDetail(int id);
        void UpdatePaymentDetail(PaymentDetail paymentDetail);
        void Save();

    }
}
