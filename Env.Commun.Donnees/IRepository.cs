using Env.Commun.Domaine;
using System;

namespace Env.Commun.Donnees
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}