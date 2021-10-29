using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentAPI.Controllers
{
    #region automatic generate controller
    //[Route("api/[controller]")]
    //[ApiController]
    //public class PaymentDetailsController : ControllerBase
    //{
    //    private readonly PaymentDetailContext _context;

    //    public PaymentDetailsController(PaymentDetailContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/PaymentDetails
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
    //    {
    //        return await _context.PaymentDetails.ToListAsync();
    //    }

    //    // GET: api/PaymentDetails/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
    //    {
    //        var paymentDetail = await _context.PaymentDetails.FindAsync(id);

    //        if (paymentDetail == null)
    //        {
    //            return NotFound();
    //        }

    //        return paymentDetail;
    //    }

    //    // PUT: api/PaymentDetails/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
    //    {
    //        if (id != paymentDetail.PaymentDetailId)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(paymentDetail).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!PaymentDetailExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/PaymentDetails
    //    [HttpPost]
    //    public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
    //    {
    //        _context.PaymentDetails.Add(paymentDetail);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
    //    }

    //    // DELETE: api/PaymentDetails/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeletePaymentDetail(int id)
    //    {
    //        var paymentDetail = await _context.PaymentDetails.FindAsync(id);
    //        if (paymentDetail == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.PaymentDetails.Remove(paymentDetail);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool PaymentDetailExists(int id)
    //    {
    //        return _context.PaymentDetails.Any(e => e.PaymentDetailId == id);
    //    }
    //}
    #endregion
    #region automatic generate controller
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentRepository paymentRepository;
        private readonly PaymentDetailContext _context;

        public PaymentDetailsController(PaymentDetailContext context)
        {
            _context = context;
            paymentRepository = new PaymentRepository(context);
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
            return paymentRepository.GetPaymentDetails();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public ActionResult<PaymentDetail> GetPaymentDetail(int id)
        {
            try
            {
                return paymentRepository.GetPaymentDetailById(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/PaymentDetails/5
        [HttpPut("{id}")]
        public ActionResult PutPaymentDetail(PaymentDetail paymentDetail)
        {
            paymentRepository.UpdatePaymentDetail(paymentDetail);
            try
            {
                paymentRepository.Save();
                return StatusCode(200);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        // POST: api/PaymentDetails
        [HttpPost]
        public ActionResult PostPaymentDetail(PaymentDetail paymentDetail)
        {
            paymentRepository.InsertPaymentDetail(paymentDetail);
            try
            {
                paymentRepository.Save();
                return StatusCode(200);
            }
            catch
            {
                return NoContent();
            }
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public ActionResult DeletePaymentDetail(int id)
        {
            paymentRepository.DeletePaymentDetail(id);
            try
            {
                paymentRepository.Save();
                return StatusCode(200);
            }
            catch
            {
                return NotFound();
            }
        }
    }
    #endregion
}
