using System;
using System.Collections.Generic;
using System.Diagnostics;
using MECEList.DatabaseContext;
using MECEList.Entities.Models;

namespace readxlxstodb
{
    public static class DataHelper
    {
        public static void InsertCategory(Category category)
        {
            var ctx = new MECEListContext();
            ctx.Categories.Add(category);
            ctx.SaveChanges();
        }
    }
}
