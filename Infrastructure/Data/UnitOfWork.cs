using System;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork
    {
        private ArchiveContext _context; 
        public UnitOfWork(ArchiveContext context)
        {
            this._context = context; 
        }
        private BoxRepository _boxRepo;
        public BoxRepository _BoxRepo 
        {
            get 
            {
                if (_boxRepo == null)
                {
                    _boxRepo = new BoxRepository(_context);
                }
                
                return _boxRepo;
            }
        }
        private PolicyRepository _policyRepo; 
        public PolicyRepository _PolicyRepo
        {
            get 
            {
                if (_policyRepo == null)
                {
                    _policyRepo = new PolicyRepository(_context);
                }
                
                return _policyRepo;
            }
        }
        public void Savechanges()
        {
             _context.SaveChanges();
        }
    }
}