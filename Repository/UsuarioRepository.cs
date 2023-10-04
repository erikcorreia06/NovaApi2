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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

    }
}