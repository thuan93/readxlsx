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

internal class Program
{
    private static void Main(string[] args)
    {

        //Sheet1
        var Jan = ReadExcelFile("../TV.xlsx", "B4", "AF21", 1);
        var Feb = ReadExcelFile("../TV.xlsx", "B4", "AF21", 2);
        var Mar = ReadExcelFile("../TV.xlsx", "B4", "AF21", 3);
        var Apr = ReadExcelFile("../TV.xlsx", "B4", "AF21", 4);
        var May = ReadExcelFile("../TV.xlsx", "B4", "AF21", 5);
        var Jul = ReadExcelFile("../TV.xlsx", "B4", "AF21", 6);
        var Jun = ReadExcelFile("../TV.xlsx", "B4", "AF21", 7);
        var Aug = ReadExcelFile("../TV.xlsx", "B4", "AF21", 8);
        var Sep = ReadExcelFile("../TV.xlsx", "B4", "AF21", 9);
        var Oct = ReadExcelFile("../TV.xlsx", "B4", "AF21", 10);
        var Nov = ReadExcelFile("../TV.xlsx", "B4", "AF21", 11);
        var Dec = ReadExcelFile("../TV.xlsx", "B4", "AF21", 12);
        var Todos = new List<Todo>
        {
            CreateTodo("1",Jan),
            CreateTodo("2",Feb),
            CreateTodo("3",Mar),
            CreateTodo("4",Apr),
            CreateTodo("5",May),
            CreateTodo("6",Jul),
            CreateTodo("7",Jun),
            CreateTodo("8",Aug),
            CreateTodo("9",Sep),
            CreateTodo("10",Oct),
            CreateTodo("11",Nov),
            CreateTodo("12",Dec)
        };
        var json = JsonConvert.SerializeObject(Todos, Formatting.Indented);
        //Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<object>>(Encoding.Default.GetString(decompressed), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        string fileName = "mecelist.json";
        //var json = JsonSerializer.Serialize<List<Todo>>(Todos);
        File.WriteAllText(fileName, json);
    }

    public static Todo CreateTodo(string month, List<object[]> jan)
    {
        var todo1 = new Todo();
        todo1.Month = month;
        todo1.Day = new List<Day>();
        for (int i = 0; i < 31; i++)
        {
            todo1.Day.Add(new Day
            {
                Title = $"{i + 1}",
                WhatDays = new WhatDay
                {
                    WhatDays = new List<string>()
                },
                BirthDays = new BirthDay
                {
                    BirthDays = new List<string>()
                },
                Events = new Event
                {
                    Evets = new List<string>()
                }
            });
        }
        var birday = jan.GetRange(0, 6);
        var whatday = jan.GetRange(6, 5);
        var evets = jan.Skip(11);
        foreach (var item in birday)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] is string str)
                {
                    todo1.Day[i].BirthDays.BirthDays.Add(str);
                }
            }
        }
        foreach (var item in whatday)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] is string str)
                {
                    todo1.Day[i].WhatDays.WhatDays.Add(str);
                }
            }
        }
        foreach (var item in evets)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] is string str)
                {
                    todo1.Day[i].Events.Evets.Add(str);
                }
            }
        }
        return todo1;
    }



    public static List<object[]> ReadExcelFile(string filePath, string CellStart, string CellEnd, int intdexCell)
    {
        var matchStart = Regex.Match(CellStart, @"(?<col>[A-Z]+)(?<row>\d+)");
        var colStringStart = matchStart.Groups["col"].ToString();
        var colStart = int.Parse(colStringStart.Select((t, i) => (colStringStart[i] - 64) * Math.Pow(26, colStringStart.Length - i - 1)).Sum().ToString()) - 1;
        var rowStart = int.Parse(matchStart.Groups["row"].ToString()) - 2;
        rowStart = rowStart > 0 ? rowStart : 0;
        var matchEnd = Regex.Match(CellEnd, @"(?<col>[A-Z]+)(?<row>\d+)");
        var colStringEnd = matchEnd.Groups["col"].ToString();
        var colEnd = int.Parse(colStringEnd.Select((t, i) => (colStringEnd[i] - 64) * Math.Pow(26, colStringEnd.Length - i - 1)).Sum().ToString()) - 1;
        var rowEnd = int.Parse(matchEnd.Groups["row"].ToString());
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {

            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            {
                var conf = new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = a => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet dataSet = reader.AsDataSet(conf);

                DataRowCollection row = dataSet.Tables[intdexCell].Rows;
                var rowList = new List<object[]>();
                for (int i = rowStart; i < rowEnd - 1; i++)
                {
                    object[] item = new object[colEnd - colStart + 1];
                    var point = 0;
                    if (row.Count - 1 < i)
                        continue;
                    for (int j = colStart; j <= colEnd; j++)
                    {
                        if (row[i].ItemArray.Length - 1 < j)
                            continue;
                        item[point] = row[i].ItemArray[j];
                        point++;
                    }
                    rowList.Add(item);
                }
                return rowList;

            }
        }
    }
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
    public Event Events { get; set; }
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
public class Event
{
    public string Title { get; set; } = "過去の出来事";
    public List<string> Evets { get; set; }
}