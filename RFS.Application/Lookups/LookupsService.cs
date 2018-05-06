using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core.Enums;
namespace RFS.Application
{
    public class LookupsService
    {
        public static LookupsService Instance { get; private set; }

        private LookupsService()
        {
        }
        static LookupsService()
        {
            Instance = new LookupsService();
        }
        public IEnumerable<KeyValuePair<int, string>> GetNationalities()
        {
            //return Enum.GetValues(typeof(NationalityType)).Cast<NationalityType>();
           return  GetEnumList<NationalityType>();
        }
        public IEnumerable<KeyValuePair< int,string>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair< int, string>>();

            foreach(var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<int, string>((int)e, e.ToString()));
            }
            return list;
        }
    }
}
