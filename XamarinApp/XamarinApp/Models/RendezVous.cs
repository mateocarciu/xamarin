using SQLite;
using System;

namespace XamarinApp.Models
{
    public class RendezVous
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Commercial { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Heure { get; set; }

    }
}