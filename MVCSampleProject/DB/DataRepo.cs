using MVCSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSampleProject.DB
{
    public class DataRepo
    {
        SampleAPIDataEntities context = new SampleAPIDataEntities();

        public void AddJSONTable(JSONTable objDetails)
        {
            context.JSONTables.Add(objDetails);
            context.SaveChanges();
        }

        public List<JSONTable> GetAllJSONTable()
        {
            var data = context.JSONTables.ToList();
            return data;
        }
        public JSONTable GetJSONTable(int? id)
        {
            var data = context.JSONTables.Where(x => x.id == id).FirstOrDefault();
            return data;
        }

        public void UpdateJSONTable(JSONTable objJSONTable)
        {
            context.Entry(objJSONTable).State = EntityState.Modified;
            context.SaveChanges();
        }
        public JSONTable DeleteJSONTable(int? id)
        {
            JSONTable obj = context.JSONTables.Where(x => x.id == id).FirstOrDefault();
            context.JSONTables.Remove(obj);
            //context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
            return obj;
        }
    }
}