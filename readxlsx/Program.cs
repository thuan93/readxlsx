// See https://aka.ms/new-console-template for more information

using ExcelDataReader;
using System.Data;
using System.Text.RegularExpressions;
using MECEList.DatabaseContext;
using System.Collections.Generic;
using MECEList.Entities.Models;
using readxlxstodb;
using System.Reflection;

internal class Program
{
    private static async Task Main(string[] args)
    {
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
        Task.Run( async () =>
        {
            _ = await SaveCatergory(categorys);
        });

        await Task.Delay(5000);
    }

    private static Task<bool> SaveCatergory(List<Category> categories)
    {
        try
        {
            foreach (var item in categories)
            {
                DataHelper.InsertCategory(item);
            }

            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}