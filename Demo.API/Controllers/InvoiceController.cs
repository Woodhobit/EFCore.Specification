using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.BLL.DTO;
using Demo.BLL.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceManager invoiceManager;
        private readonly ILogger<InvoiceController> logger;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceManager invoiceManager)
        {
            this.logger = logger;
            this.invoiceManager = invoiceManager;
        }


        [HttpGet("All")]
        public async Task<ActionResult<List<InvoiceOverviewDto>>> GetOverview([FromQuery] string customer = null)
        {
            if (string.IsNullOrEmpty(customer))
            {
                return Ok(await this.invoiceManager.GetAllInvoices());
            }

            return Ok(await this.invoiceManager.GetAllInvoicesByCustomer(customer));
        }

        [HttpGet("Unpaid")]
        public async Task<ActionResult<List<PaidInvoiceDto>>> GetUnpaid(
            [FromQuery] DateTime? dueDate,
            [FromQuery] string customer = null)
        {
            if (string.IsNullOrEmpty(customer) && dueDate == null)
            {
                return Ok(await this.invoiceManager.GetAllUnPaidInvoices());
            }

            if (!string.IsNullOrEmpty(customer) && dueDate == null)
            {
                return Ok(await this.invoiceManager.GetAllUnPaidInvoicesByCustomer(customer));
            }

            return Ok(await this.invoiceManager.GetAllUnPaidInvoicesByCustomerDueDate(customer, dueDate.Value));
        }

        [HttpGet("v2/Unpaid")]
        public async Task<ActionResult<List<PaidInvoiceDto>>> GetUnpaidNew(
            [FromQuery] DateTime? dueDate,
            [FromQuery] string customer = null)
        {
            return Ok(await this.invoiceManager.GetAllUnPaidInvoices(customer, dueDate));
        }
    }
}
