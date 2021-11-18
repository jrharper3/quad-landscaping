using System;
using System.Dynamic;
using System.Collections.Generic;
using API.Models;
using API.Models.Interfaces;
using API.Data;

namespace API.Data
{
    public class PlantDataHandler : IPlantDataHandler
    {
        private Database db;
        public PlantDataHandler()
        {
            db = new Database();
        }
        public void Delete(Plant plants)
        {
            string sql = "UPDATE posts SET deleted = 'Y' WHERE plantid = @plantid";

            var values = GetValues(plants);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Plant plants)
        {
            string sql = "INSERT INTO plants (PlantName, PlantSpeciesName, PlantDifficultyLevel, PlantPic, PlantDescription, PlantViews, CreatedByAccountID)";
            sql += "VALUES (@PlantName, @PlantSpeciesName, @PlantDifficultyLevel, @PlantPic, @PlantDescription, @PlantViews, @CreatedByAccountID)";

            var values = GetValues(plants);
            db.Open();
            db.Insert(sql, values);
            db.Close();

        }

        public List<Plant> Select()
        {
            
            db.Open();
            string sql = "SELECT * FROM plants";//WHERE deleted = 'N'";
            List<ExpandoObject> results = db.Select(sql);

            List<Plant> plants = new List<Plant>();
            foreach(dynamic item in results)
            {
                Plant temp = new Plant(){
                    PlantId = item.PlantId,
                    PlantName = item.PlantName,
                    PlantSpeciesName = item.PlantSpeciesName,
                    PlantDifficultyLevel = item.PlantDifficultyLevel,
                    PlantPic = item.PlantPic,
                    PlantDescription = item.PlantDescription,
                    PlantViews = item.PlantViews,
                    CreatedByAccountID = item.CreatedByAccountID,


                };
                plants.Add(temp);
            }
            db.Close();

            return plants;
        }

        public void Update(Plant plants)
        {
           string sql = "UPDATE posts SET PlantName = @PlantName, PlantSpeciesName = @PlantSpeciesName, PlantDifficultyLevel = @PlantDifficultyLevel, PlantPic = @PlantPic, PlantDescription = @PlantDescription, PlantViews = @PlantViews, CreatedByAccountID = @CreatedByAccountID)";

            var values = GetValues(plants);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }
        public Dictionary<string, object> GetValues(Plant plants)
        {
            var values = new Dictionary<string,object>(){
                {"@plantid", plants.PlantId},
                {"@PlantName", plants.PlantName},
                {"@PlantSpeciesName", plants.PlantSpeciesName},
                {"@PlantDifficultyLevel",plants.PlantDifficultyLevel},
                {"@PlantPic", plants.PlantPic},
                {"@PlantDescription", plants.PlantDescription},
                {"@PlantViews",plants.PlantViews},
                {"@CreatedByAccountID", plants.CreatedByAccountID}

            }; 
            return values;
        }
    }
}