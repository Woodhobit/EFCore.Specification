using Demo.BLL.DTO;
using Demo.BLL.Specifications.Invoices;
using Demo.DAL.Contracts;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using QueryBuilder.Builder;
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

        public Task<List<InvoiceDto>> GetAllPaidInvoices()
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == true)
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<InvoiceDto>> GetAllPaidInvoicesByCustomer(string customer)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == true && x.Customer.Name.Contains(customer))
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<InvoiceDto>> GetAllUnPaidInvoices()
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false)
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<InvoiceDto>> GetAllUnPaidInvoicesByCustomer(string customer)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false && x.Customer.Name.Contains(customer))
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public Task<List<InvoiceDto>> GetAllUnPaidInvoicesByCustomerDueDate(string customer, DateTime dueDate)
        {
            return this.repository.GetAll()
                .Where(x => x.IsPaid == false && x.Customer.Name.Contains(customer) && x.DueDate == dueDate)
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Customer = x.Customer.Name,
                    Number = x.InvoiceNo
                })
                .ToListAsync();
        }

        public async Task<List<InvoiceDto>> GetAllUnPaidInvoices(string customer, DateTime? dueDate)
        {
            InvoiceByCustomerSpecification invoiceByCustomer;
            InvoiceDueDateSpecification dueDateInvoice;

            var orderByDate = new InvoiceOrderedByDateSpecification();
            var unpaidInvoice = new UnpaidInvoiceSpecification();

            var queryBuilder = new QueryWithProjectionBuilder<Invoice, InvoiceDto>();
            queryBuilder.AddOrderBy(orderByDate).AddSelector(new SelectInvoiceSpecification());


            if (string.IsNullOrEmpty(customer) && dueDate == null)
            {
                queryBuilder.AddFilter(unpaidInvoice);
            }

            if (!string.IsNullOrEmpty(customer) && dueDate == null)
            {
                invoiceByCustomer = new InvoiceByCustomerSpecification(customer);
                var unpaidIvoiceByCustomer = unpaidInvoice.And(invoiceByCustomer);

                queryBuilder.AddFilter(unpaidIvoiceByCustomer);
            }

            if (!string.IsNullOrEmpty(customer) && dueDate.HasValue)
            {
                invoiceByCustomer = new InvoiceByCustomerSpecification(customer);
                dueDateInvoice = new InvoiceDueDateSpecification(dueDate.Value);
                var updaidIvoiceByCustomerAndDueDate = unpaidInvoice.And(invoiceByCustomer).And(dueDateInvoice);

                queryBuilder.AddFilter(updaidIvoiceByCustomerAndDueDate);
            }

            var result = await this.repository.QueryAsync(queryBuilder.GetQuery());

            return result;
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
