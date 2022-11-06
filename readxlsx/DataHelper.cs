﻿using System;
using System.Diagnostics;
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
                ctx.Categories.Add(category);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void InsertItem(Item item)
        {
            try
            {
                var ctx = new MECEListContext();
                ctx.Items.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void InsertList(List list)
        {
            try
            {
                var ctx = new MECEListContext();
                ctx.Lists.Add(list);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void InsertAttribute(Attrib attrib)
        {
            try
            {
                if (attrib.Name.Length == 0)
                    return;
                var ctx = new MECEListContext();
                ctx.Attribs.Add(attrib);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}