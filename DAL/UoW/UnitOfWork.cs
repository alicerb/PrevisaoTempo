﻿using DAL.Interfaces;
using PrevisaoTempo.DAL.Context;
using System;


namespace PrevisaoTempo.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrevisaoTempoContext _context;
        private bool _disposed;

        public UnitOfWork(PrevisaoTempoContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}