// See https://aka.ms/new-console-template for more information

using ExcelDataReader;
using System.Data;
using System.Text.RegularExpressions;
using MECEList.DatabaseContext;
using System.Collections.Generic;
using MECEList.Entities.Models;
using readxlxstodb;
using System.Linq;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {

        var json = ReadResourceFile("readxlsx.mecelist.json");
        var data = JsonConvert.DeserializeObject<TodoGroup>(json);

        var dem = 0;
        var dem1 = 0;
        var dem2 = 0;
        for (int i = 0; i < data.Count; i++)
        {
            var item = data[i];
            for (int i1 = 0; i1 < item.Day.Count; i1++)
            {
                var day = item.Day[i1];
                //birthday - Celebrity
                for (int i2 = 0; i2 < day.BirthDays.BirthDays.Count; i2++)
                {
                    string bir = day.BirthDays.BirthDays[i2];
                    var celebrity = new Celebrity { Day = i1 + 1, Month = i + 1, Name = bir, CelebrityId = ++dem ,Id = dem};
                    DataHelper.InsertCelebrity(celebrity);
                }

                //What day - Anniversary
                for (int i2 = 0; i2 < day.WhatDays.WhatDays.Count; i2++)
                {
                    string bir = day.WhatDays.WhatDays[i2];
                    var anniversary = new Anniversary { Day = i1 + 1, Month = i + 1, Name = bir, AnniversaryId = ++dem1, Id = dem1 };
                    DataHelper.InsertAnniversary(anniversary);
                }
                //Event - Event
                for (int i2 = 0; i2 < day.Events.Evets.Count; i2++)
                {
                    string bir = day.Events.Evets[i2];
                    var anniversary = new Event { Day = i1 + 1, Month = i + 1, Name = bir, EventId = ++dem2, Id = dem2 };
                    DataHelper.InsertEvent(anniversary);
                }
            }



            //Event - Event
        }
    }

    private static string ReadResourceFile(string filename)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();
        using (var stream = thisAssembly.GetManifestResourceStream(filename))
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    
}

public class TodoGroup:List<Todo>
{
    
}

public class Todo
{
    public string Month { get; set; }
    public List<Day> Day { get; set; }

}
public class Day
{
    public string Title { get; set; }
    public BirthDay BirthDays { get; set; }
    public WhatDay WhatDays { get; set; }
    public Events Events { get; set; }
}

public class BirthDay
{
    public string Title { get; set; } = "誕生日";
    public List<string> BirthDays { get; set; }
}
public class WhatDay
{
    public string Title { get; set; } = "何の日";
    public List<string> WhatDays { get; set; }
}
public class Events
{
    public string Title { get; set; } = "過去の出来事";
    public List<string> Evets { get; set; }
}