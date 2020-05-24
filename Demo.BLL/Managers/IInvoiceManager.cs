using Demo.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.BLL.Managers
{
    public interface IInvoiceManager
    {
        Task<List<InvoiceOverviewDto>> GetAllInvoices();
        Task<List<InvoiceOverviewDto>> GetAllInvoicesByCustomer(string customer);
        Task<List<PaidInvoiceDto>> GetAllPaidInvoices();
        Task<List<PaidInvoiceDto>> GetAllPaidInvoicesByCustomer(string customer);
        Task<List<PaidInvoiceDto>> GetAllUnPaidInvoices();
        Task<List<PaidInvoiceDto>> GetAllUnPaidInvoicesByCustomer(string customer);
        Task<List<PaidInvoiceDto>> GetAllUnPaidInvoicesByCustomerDueDate(string customer, DateTime dueDate);
        Task<List<PaidInvoiceDto>> GetAllUnPaidInvoices(string customer, DateTime? dueDate);
    }
}