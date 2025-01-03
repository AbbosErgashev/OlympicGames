﻿namespace OlympicGames.Infrastructure.IRepositories.Base
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
