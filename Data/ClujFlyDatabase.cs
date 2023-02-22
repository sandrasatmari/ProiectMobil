using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMobil.Models;

namespace ProiectMobil.Data
{
    public class ClujFlyDatabase
    {
        readonly SQLiteAsyncConnection _database; 
        public ClujFlyDatabase(string dbPath) 
        { 
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<CountryList>().Wait();
            _database.CreateTableAsync<Oras>().Wait();
            _database.CreateTableAsync<ListOras>().Wait();
            _database.CreateTableAsync<Cazare>().Wait();

        }
        public Task<List<CountryList>> GetCountryListsAsync() 
        { 
            return _database.Table<CountryList>().ToListAsync(); 
        }
        public Task<CountryList> GetCountryListAsync(int id) 
        { 
            return _database.Table<CountryList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync(); 
        }
        public Task<int> SaveCountryListAsync(CountryList slist) 
        { 
            if (slist.ID != 0) 
            { 
                return _database.UpdateAsync(slist); 
            } 
            else 
            { 
                return _database.InsertAsync(slist); 
            } 
        }
        public Task<int> DeleteCountryListAsync(CountryList slist) 
        { 
            return _database.DeleteAsync(slist); 
        }
        public Task<int> SaveOrasAsync(Oras oras)
        {
            if (oras.ID != 0)
            {
                return _database.UpdateAsync(oras);
            }
            else
            {
                return _database.InsertAsync(oras);
            }
        }
        public Task<int> DeleteOrasAsync(Oras oras)
        {
            
            return _database.DeleteAsync(oras);
         
        }
        public Task<List<Oras>> GetOraseAsync()
        {
            return _database.Table<Oras>().ToListAsync();
        }
        public Task<int> SaveListOrasAsync(ListOras listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Oras>> GetListOraseAsync(int countryListid)
        {
            return _database.QueryAsync<Oras>(
            "select P.ID, P.Description from Oras P"
            + " inner join ListOras LP"
            + " on P.ID = LP.OrasID where LP.CountryListID = ?",
            countryListid);
        }
        public Task<List<Cazare>> GetCazariAsync()
        {
            return _database.Table<Cazare>().ToListAsync();
        }
        public Task<int> SaveCazareAsync(Cazare cazare)
        {
            if (cazare.ID != 0)
            {
                return _database.UpdateAsync(cazare);
            }
            else
            {
                return _database.InsertAsync(cazare);
            }
        }
        public Task<int> DeleteCazareAsync(Cazare cazare)
        {

            return _database.DeleteAsync(cazare);

        }
    }
}

