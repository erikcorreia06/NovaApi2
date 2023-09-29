using NovaApi2.Models.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NovaApi2.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> Get();
        Usuario GetById(int id);
        void Add(Usuario entity);
        void Delete(Usuario entity);
        void Update(Usuario entity);
    }
}
