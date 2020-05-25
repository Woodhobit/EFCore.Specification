using Demo.BLL.Specifications.Invoices;
using Demo.DAL.Models;
using QueryBuilder.Builder;
using SpecificationAndQueryBuilderTests.Fixture;
using System;
using System.Linq;
using Xunit;
using QueryBuilder.Extensions;
using Demo.BLL.DTO;

namespace SpecificationAndQueryBuilderTests
{
    public class QueryBuilderTests : IClassFixture<DataFixture>
    {
        private readonly IQueryable<Invoice> Invoices;

        public QueryBuilderTests(DataFixture fixture)
        {
            this.Invoices = fixture.Invoices;
        }

        [Fact]
        public void DataIsFitered()
        {
            var dueDate = DateTime.Now.AddDays(4);

            // Arrange
            var unpaidInvoice = new UnpaidInvoiceSpecification();
            var dueDateInvoice = new InvoiceDueDateSpecification(dueDate);
            var queryBuilder = new QueryBuilder<Invoice>()
                .AddFilter(unpaidInvoice.And(dueDateInvoice));

            // Act
            var result = this.Invoices.EvaluateQuery(queryBuilder.GetQuery()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.True(result.All(x => x.DueDate.Date == dueDate.Date));
            Assert.True(result.All(x => x.IsPaid == false));
        }

        [Fact]
        public void DataIsOrderedBy()
        {
            var expectedOrder = this.Invoices.OrderBy(x => x.Date).ToArray();

            // Arrange
            var queryBuilder = new QueryBuilder<Invoice>()
                .AddOrderBy(new InvoiceOrderedByDateSpecification());

            // Act
            var result = this.Invoices.EvaluateQuery(queryBuilder.GetQuery()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedOrder.Length, result.Count);

            for (int i = 0; i < expectedOrder.Length; i++)
            {
                var expected = expectedOrder[i].Id;
                var actual = result[i].Id;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void DataIsOrderedByDescending()
        {
            var expectedOrder = this.Invoices.OrderByDescending(x => x.Date).ToArray();

            // Arrange
            var queryBuilder = new QueryBuilder<Invoice>()
                .AddOrderByDescending(new InvoiceOrderedByDateSpecification());

            // Act
            var result = this.Invoices.EvaluateQuery(queryBuilder.GetQuery()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedOrder.Length, result.Count);

            for (int i = 0; i < expectedOrder.Length; i++)
            {
                var expected = expectedOrder[i].Id;
                var actual = result[i].Id;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void DataIsProjected()
        {
            // Arrange
            var queryBuilder = new QueryWithProjectionBuilder<Invoice, InvoiceDto>()
                .AddFilter(new UnpaidInvoiceSpecification())
                .AddSelector(new SelectInvoiceSpecification());

            // Act
            var result = this.Invoices.EvaluateQuery(queryBuilder.GetQuery()).ToList();

            // Assert
            Assert.NotEmpty(result);

            var expectedType = typeof(InvoiceDto);
            var actualType = result.First();
            Assert.IsType(expectedType, actualType);
        }
    }
}
