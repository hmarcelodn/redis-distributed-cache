using Newtonsoft.Json;
using SouthWorks.Events.Infrastructure.Cache;
using SouthWorks.Events.Solution.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SouthWorks.Events.Solution.Data
{
    public class EventsDataReader
    {
        protected const int TOTAL_ROWS = 180;

        public static DataTableDataModel ReadEvents(int echo, int start, int length, string search)
        {
            var eventsRepository = new RedisCacheRepository();
            var array = new List<List<string>>();            

            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/MOCK_DATA.json"))
            {
                string json = r.ReadToEnd();
                array = JsonConvert.DeserializeObject<List<List<string>>>(json);
            }            

            return new DataTableDataModel()
            {
                aaData = array.GetRange(start, Math.Min(length, array.Count - start)),
                sEcho = echo,
                iTotalDisplayRecords = array.Count,
                iTotalRecords = TOTAL_ROWS
            };
        }
    }
}