﻿using System;
using System.Collections.Generic;
using System.IO;
using Countr.Core.Models;
using SQLite;
using System.Threading.Tasks;

namespace Countr.Core.Repositories
{
    public class CountersRepository : ICountersRepository
    {
        readonly SQLiteAsyncConnection connection;

        public CountersRepository()
        {
            var local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var datafile = Path.Combine(local, "counters.db3");
            connection = new SQLiteAsyncConnection(datafile);
            connection.GetConnection().CreateTable<Counter>();
        }

        public Task Save(Counter counter)
        {
            return connection.InsertOrReplaceAsync(counter);
        }

        public Task<List<Counter>> GetAll()
        {
            return connection.Table<Counter>().ToListAsync();
        }

        public Task Delete(Counter counter)
        {
            return connection.DeleteAsync(counter);
        }
    }
}
