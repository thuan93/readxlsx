// See https://aka.ms/new-console-template for more information

using ExcelDataReader;
using System.Data;
using System.Text.RegularExpressions;
using MECEList.DatabaseContext;
using System.Collections.Generic;
using MECEList.Entities.Models;
using readxlxstodb;

internal class Program
{
    private static void Main(string[] args)
    {

        //Sheet1
        var attribute = ReadExcelFile("../TV.xlsx", "C2", "FY2", 2);

        var items = ReadExcelFile("../TV.xlsx", "C3", "FY3", 2);

        var lists = ReadExcelFile("../TV.xlsx", "A4", "B94", 2);

        var allSheet1 = ReadExcelFile("../TV.xlsx", "C4", "FY94", 2);

        //Sheet2
        var attribute2 = ReadExcelFile("../TV.xlsx", "C2", "BX2", 3);

        var items2 = ReadExcelFile("../TV.xlsx", "C3", "BX3", 3);

        var allSheet2 = ReadExcelFile("../TV.xlsx", "C4", "BX94", 3);

        var allItems = new List<Item>();

        var allList = new List<List>();

        //Category
        var categorys = new List<Category>()
        {
            new Category
            {
                Id = 17,
                Categoryid = 30,
                Name = "肉料理",
                Rootid = 7
            },
            new Category
            {
                Id = 18,
                Categoryid = 31,
                Name = "魚料理",
                Rootid = 7
            },
            new Category
            {
                Id = 19,
                Categoryid = 32,
                Name = "野菜料理",
                Rootid = 7
            },
            new Category
            {
                Id = 20,
                Categoryid = 33,
                Name = "汁物・鍋など",
                Rootid = 7
            },
            new Category
            {
                Id = 21,
                Categoryid = 34,
                Name = "丼もの・麺類など",
                Rootid = 7
            },
        };

        //Attribute
        var allAtribute = new List<Attrib>();
        for (int i = 0; i < attribute[0].Count(); i++)
        {
            if (attribute[0][i] is not string str)
                continue;
            var att = new Attrib
            {
                Id = allAtribute.LastOrDefault() != null ? allAtribute.LastOrDefault().Id + 1 : 30,
                Name = str,
                Rootid = 5,
                AttribId = allAtribute.LastOrDefault() != null ? allAtribute.LastOrDefault().AttribId + 1 : 31,
            };

            allAtribute.Add(att);
        }

        for (int i = 0; i < attribute2[0].Count(); i++)
        {
            if (attribute2[0][i] is not string str || string.IsNullOrEmpty(str))
                continue;
            var att = new Attrib
            {
                Id = allAtribute.LastOrDefault().Id + 1,
                Name = str,
                Rootid = 5,
                AttribId = allAtribute.LastOrDefault().AttribId + 1
            };

            allAtribute.Add(att);
        }

        //Lists
        for (int i = 0; i < lists.Count; i++)
        {
            if (lists[i][0] is not string str)
                continue;
            if (lists[i][1] is not double categoryId)
            {
                allList.Add(new List
                {
                    Id = 53 + i,
                    RootId = 5,
                    ListId = 143 + i,
                    ListName = str,
                    Categoryid = -1
                });
                continue;
            }
            var category = categorys[(int)categoryId - 1];
            var lst = new List
            {
                Id = 53 + i,
                RootId = 7,
                ListId = 143 + i,
                ListName = str,
                Categoryid = category.Id,
                CategoryName = category.Name,
            };

            allList.Add(lst);
        }

        

        for (int i = 0; i < allSheet1.Count; ++i)
        {
            var list = allList[i];
            Attrib oldAttribute = null;

            for (int j = 0; j < allSheet1[i].Count(); j++)
            {
                var item = new Item();
                var attrName = attribute[0][j];
                if (attrName != null && attrName is string attrstr)
                {
                    var found = allAtribute.FirstOrDefault(x => x.Name.Contains(attrstr));
                    if (found != null)
                        oldAttribute = found;
                }

                if (allSheet1[i][j] is not string str)
                {
                   continue;
                }
                item.Attrib = oldAttribute.AttribId;
                item.ListId = list.ListId;
                item.ItemId = allItems.Count > 0 ? allItems.Max(x=>x.ItemId) + 1 : 1929;
                item.Id = item.ItemId;
                if (items[0][j] is not string name)
                    continue;
                item.ItemName = name;

                allItems.Add(item);
            }
            
        }

        for (int i = 0; i < allSheet2.Count; ++i)
        {
            var list = allList[i];

            var attrName = allAtribute.LastOrDefault();

            for (int j = 0; j < allSheet2[i].Count(); j++)
            {
                var item = new Item();

                if (allSheet2[i][j] is not string str)
                {
                    continue;
                }
                item.Attrib = attrName.AttribId;
                item.ListId = list.ListId;
                item.ItemId = allItems.Count > 0 ? allItems.Max(x => x.ItemId) + 1 : 1929;
                item.Id = item.ItemId;
                if (items2[0][j] is not string name)
                    continue;
                item.ItemName = name;

                allItems.Add(item);
            }
        }

        foreach (var item in allAtribute)
        {
            DataHelper.InsertAttribute(item);
        }
        foreach (var item in allList)
        {
            DataHelper.InsertList(item);
        }
        foreach (var item in categorys)
        {
            DataHelper.InsertCategory(item);
        }
        foreach (var item in allItems)
        {
            DataHelper.InsertItem(item);
        }
    }



    public static List<object[]> ReadExcelFile(string filePath, string CellStart, string CellEnd, int intdexCell)
    {
        var matchStart = Regex.Match(CellStart, @"(?<col>[A-Z]+)(?<row>\d+)");
        var colStringStart = matchStart.Groups["col"].ToString();
        var colStart = int.Parse(colStringStart.Select((t, i) => (colStringStart[i] - 64) * Math.Pow(26, colStringStart.Length - i - 1)).Sum().ToString()) - 1;
        var rowStart = int.Parse(matchStart.Groups["row"].ToString()) - 2;

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
                    for (int j = colStart; j <= colEnd; j++)
                    {
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