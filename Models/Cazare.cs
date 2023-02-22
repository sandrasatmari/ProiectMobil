using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace ProiectMobil.Models
{
    public class Cazare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CazareName { get; set; }
        public string Adress { get; set; }
        public string CazareDetails
        {
            get
            {
                return CazareName + " " + Adress;
            }
        }
        [OneToMany]
        public List<CountryList> CountryLists { get; set; }
    }
}
