using System;
using MECEList.DatabaseContext;
using MECEList.Entities.Models;

namespace readxlxstodb
{
    public static class DataHelper
    {
        public static void InsertCategory(Category category)
        {
            try
            {
                var ctx = new MECEListContext();
                ctx.Add(category);
            }
            catch (Exception ex)
            {

            }
        }

        public static void InsertItem(Item item)
        {
            try
            {
                var ctx = new MECEListContext();
                ctx.Add(item);
            }
            catch (Exception ex)
            {

            }
        }

        public static void InsertList(List list)
        {
            try
            {
                var ctx = new MECEListContext();
                ctx.Add(list);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
