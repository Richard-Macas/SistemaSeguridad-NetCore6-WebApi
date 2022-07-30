using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}
