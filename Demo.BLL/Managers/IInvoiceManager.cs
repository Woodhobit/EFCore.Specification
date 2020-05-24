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
        Task<List<InvoiceDto>> GetAllPaidInvoices();
        Task<List<InvoiceDto>> GetAllPaidInvoicesByCustomer(string customer);
        Task<List<InvoiceDto>> GetAllUnPaidInvoices();
        Task<List<InvoiceDto>> GetAllUnPaidInvoicesByCustomer(string customer);
        Task<List<InvoiceDto>> GetAllUnPaidInvoicesByCustomerDueDate(string customer, DateTime dueDate);
        Task<List<InvoiceDto>> GetAllUnPaidInvoices(string customer, DateTime? dueDate);
    }
}