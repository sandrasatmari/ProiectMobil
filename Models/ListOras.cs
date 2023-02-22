using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMobil.Models
{
    public class ListOras
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(CountryList))]
        public int CountryListID { get; set; }
        public int OrasID { get; set; }
    }
}
