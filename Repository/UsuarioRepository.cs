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
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
