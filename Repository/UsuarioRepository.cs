using Microsoft.EntityFrameworkCore;
using NovaApi2.Data.UsuarioDbContext;
using NovaApi2.Models.Domain.Usuario;
using NovaApi2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios.AsEnumerable();
        }

        public IEnumerable<Usuario> Get(Expression<Func<Usuario, bool>> predicate)
        {
            return _context.Usuarios.Where(predicate).AsEnumerable();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
