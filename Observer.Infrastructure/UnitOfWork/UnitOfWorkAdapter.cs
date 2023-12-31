﻿using Npgsql;
using Observer.Infrastructure.Repositories.Contracts;
using Observer.Infrastructure.UnitOfWork.Contracts;
using System.Data;

namespace Observer.Infrastructure.UnitOfWork
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkAdapter(string connectionString)
        {
            Initialize(connectionString);
        }

        private void Initialize(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            Repositories = new UnitOfWorkRepository(_connection, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Connection?.Close();
                _transaction.Connection?.Dispose();
                _transaction.Dispose();
            }

            _transaction = null;
            Repositories = null;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
