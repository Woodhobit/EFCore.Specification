using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Specification.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DAL.Repository
{
    public class NewRepository<T>  where T : BaseEntity
    {
        private readonly ApplicationContext context;

        private readonly DbSet<T> entities;

        public NewRepository(ApplicationContext context)
        {
            this.context = context;
            this.entities = this.context.Set<T>();
        }

        public IReadOnlyCollection<T> Get(Specification<T> specification)
        {
            return this.entities
                .Where(specification.ToExpression())
                .ToList();
        }
    }
}
