using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;
using NovaApi2.Models.Domain.Usuario;

namespace NovaApi2.Repository
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}