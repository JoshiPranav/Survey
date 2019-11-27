using System.Collections.Generic;
using System.IO;
using System.Linq;
using Api.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Api.Data.Setup
{
    public class SurveySeedDataLoader
    {
        private readonly SurveyDbContext _ctx;
        private readonly IWebHostEnvironment _htx;

        public SurveySeedDataLoader(SurveyDbContext ctx, IWebHostEnvironment htx)
        {
            _ctx = ctx;
            _htx = htx;
        }

        public void LoadData()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Surveys.Any())
            {
                var jsonDataFilePath = Path.Combine(_htx.ContentRootPath, "Data/Setup/surveydata.json");
                var json = File.ReadAllText(jsonDataFilePath);
                var surveys = JsonConvert.DeserializeObject<IEnumerable<Survey>>(json);
                _ctx.Surveys.AddRange(surveys);
                _ctx.SaveChanges();
            }
        }
    }
}
