using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using System.Linq;

namespace CourtDatabase2.Services
{
    public class SeedServiceHeatEstates : IHeatEstateSeeder
    {
        private readonly ApplicationDbContext dbContext;

        public SeedServiceHeatEstates(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void HeatEstateSeed()
        {
            //if (this.dbContext.HeatEstates.Any())
            if (this.dbContext.HeatEstates.Count() > 1)
            {
                return;
            }

            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300401", Address = "ул. Петрохан № 98, ет.13, ап. А" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300402", Address = "ул. Петрохан № 98, ет.13, ап. Б" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300403", Address = "ул. Петрохан № 98, ет.13, ап. В" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300404", Address = "ул. Петрохан № 98, ет.13, ап. Г" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300405", Address = "ул. Петрохан № 98, ет.13, ап. Д" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300406", Address = "ул. Петрохан № 98, ет.13, ап. Е" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300407", Address = "ул. Петрохан № 98, ет.13, ап. Ж" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300408", Address = "ул. Петрохан № 98, ет.13, ап. З" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300409", Address = "ул. Петрохан № 98, ет.13, ап. И" });
            this.dbContext.HeatEstates.Add(new HeatEstate { AbNumber = "13000300410", Address = "ул. Петрохан № 98, ет.13, ап. К" });
            this.dbContext.SaveChanges();
        }
    }
}
