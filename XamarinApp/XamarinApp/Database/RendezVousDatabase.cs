using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Database
{
    public class RendezVousDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public RendezVousDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RendezVous).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RendezVous)).ConfigureAwait(false);

                initialized = true;
            }
        }

        public Task<List<RendezVous>> getRendezVous()
        {
            return Database.Table<RendezVous>().ToListAsync();
        }

        public Task<int> SaveRendezVous(RendezVous rdv)
        {
            if (rdv.ID == 0)
                return Database.InsertAsync(rdv);
            else
                return Database.UpdateAsync(rdv);
        }

        public Task<int> DeleteRendezVous(RendezVous rdv)
        {
            return Database.DeleteAsync(rdv);
        }
    }
}