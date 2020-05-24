using Demo.BLL.DTO;
using Demo.BLL.Specifications.Invoices;
using Demo.DAL.Contracts;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BLL.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IRepository<Invoice> repository;

        public InvoiceManager(IRepository<Invoice> repository)
        {
            this.repository = repository;
        }

        public Task<List<PaidInvoiceDto>> GetAllPaidInvoices()
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == true)
                .Select(x => new PaidInvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<PaidInvoiceDto>> GetAllPaidInvoicesByCustomer(string customer)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == true && x.Customer.Name.Contains(customer))
                .Select(x => new PaidInvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<PaidInvoiceDto>> GetAllUnPaidInvoices()
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false)
                .Select(x => new PaidInvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<PaidInvoiceDto>> GetAllUnPaidInvoicesByCustomer(string customer)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false && x.Customer.Name.Contains(customer))
                .Select(x => new PaidInvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<PaidInvoiceDto>> GetAllUnPaidInvoicesByCustomerDueDate(string customer, DateTime dueDate)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false && x.Customer.Name.Contains(customer) && x.DueDate == dueDate)
                .Select(x => new PaidInvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public async Task<List<PaidInvoiceDto>> GetAllUnPaidInvoices(string customer, DateTime? dueDate)
        {
            UnpaidInvoiceSpecification unpaidInvoice = new UnpaidInvoiceSpecification();
            InvoiceByCustomerSpecification invoiceByCustomer;
            InvoiceDueDateSpecification dueDateInvoice;

            IReadOnlyCollection<Invoice> result = null;

            if (string.IsNullOrEmpty(customer) && dueDate == null)
            {
                result = await this.repository.GetAsync(unpaidInvoice);
            }

            if (!string.IsNullOrEmpty(customer) && dueDate == null)
            {
                invoiceByCustomer = new InvoiceByCustomerSpecification(customer);
                var unpaidIvoiceByCustomerOrderedByDate = new InvoiceOrderedByDateSpecification(unpaidInvoice.And(invoiceByCustomer));

                result = await this.repository.GetAsync(unpaidIvoiceByCustomerOrderedByDate);
            }

            if (!string.IsNullOrEmpty(customer) && dueDate.HasValue)
            {
                invoiceByCustomer = new InvoiceByCustomerSpecification(customer);
                dueDateInvoice = new InvoiceDueDateSpecification(dueDate.Value);
                var updaidIvoiceByCustomerAndDueDate = unpaidInvoice.And(invoiceByCustomer).And(dueDateInvoice);

                result = await this.repository.GetAsync(updaidIvoiceByCustomerAndDueDate);
            }

            return result.Select(x => new PaidInvoiceDto
            {
                Id = x.Id,
                Date = x.Date,
                DueDate = x.DueDate,
                Customer = x.Customer.Name, // ToDo LazyLoading
                Number = x.InvoiceNo
            }).ToList();
        }

        public Task<List<InvoiceOverviewDto>> GetAllInvoices()
        {
            return this.repository.GetAll()
                .Select(x => new InvoiceOverviewDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo,
                    IsPaid = x.IsPaid,
                    TotalSum = x.Lines.Sum(n => n.Sum)
                })
                .ToListAsync();
        }

        public Task<List<InvoiceOverviewDto>> GetAllInvoicesByCustomer(string customer)
        {
            return this.repository.GetAll()
                .Where(x => x.Customer.Name.Contains(customer))
                .Select(x => new InvoiceOverviewDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo,
                    IsPaid = x.IsPaid,
                    TotalSum = x.Lines.Sum(n => n.Sum)
                })
                .ToListAsync();
        }
    }
}
