using Card.Database.Context;
using Card.Domain.Interfaces;

namespace Card.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CardContext _context;

        public UnitOfWork(CardContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
