﻿namespace Store.DAL.Utils
{
    public static class WorkDb
    {
        private static readonly StoreEntities Db = new StoreEntities();

        //public static Dictionary<int, string> GetAllRecordFromDb()
        //{
        //    Dictionary<int, string> selected = from s in Db.routine
        //                   group s by s.Id into g
        //                   select new { Id = g.Key, Name = g.Key.ToString() };

        //    return selected;
        //}
    }
}
