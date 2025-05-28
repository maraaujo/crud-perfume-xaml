
using crud_perfume.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_perfume.Database
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _context;

        public crudSQLite(string path)
        {
            _context = new SQLiteAsyncConnection(path);
            _context.CreateTableAsync<Perfume>().Wait();
        }

        public Task<int> Insert(Perfume perfume) =>
            _context.InsertAsync(perfume);

        public Task<List<Perfume>> GetAll() =>
            _context.Table<Perfume>().ToListAsync();

        public Task<int> Delete(int id)
        {
            return _context.Table<Perfume>().DeleteAsync(i => i.Id == id);
        }


        public Task<List<Perfume>> Update(Perfume perfume)
        {
            string sql = "UPDATE Perfume SET Nome=?, Voume=? WHERE Id=?";
            return _context.QueryAsync<Perfume>(sql, perfume.Nome, perfume.Volume, perfume.Id);
        }

        public Task<List<Perfume>> Search(string nome)
        {
            string sql = $"SELECT * FROM Perfume WHERE Nome LIKE '%{nome}%'";
            return _context.QueryAsync<Perfume>(sql);
        }
    }
}
