using DataAccess.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using NovaApi2.Models.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NovaApi2.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> Get();
        Usuario GetById(int id);

    }
}


