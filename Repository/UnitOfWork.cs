using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;
using NovaApi2.Data.UsuarioDbContext;
using NovaApi2.Models.Domain.Usuario;

namespace NovaApi2.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public AppDbContext _context;
        private Repository<Usuario> _usarioRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IRepository<Usuario> UsuarioRepository
        {
            get
            {
                return _usarioRepository = _usarioRepository ?? new Repository<Usuario>(_context);
            }
        }

        public IRepository<Usuario> ClienteRepository => throw new NotImplementedException();

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
