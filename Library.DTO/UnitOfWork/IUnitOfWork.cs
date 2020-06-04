using System;

namespace Library.DTO.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}