using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using CourtDatabase2.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class SeederService : ISeederService
    {
        private readonly ApplicationDbContext dbContext;

        public SeederService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task HeatEstateSeedAsync()
        {
            if (this.dbContext.HeatEstates.Any())
            {
                return;
            }

            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300401", Address = "ул. Петрохан № 98, ет.13, ап. А" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300402", Address = "ул. Петрохан № 98, ет.13, ап. Б" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300403", Address = "ул. Петрохан № 98, ет.13, ап. В" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300404", Address = "ул. Петрохан № 98, ет.13, ап. Г" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300405", Address = "ул. Петрохан № 98, ет.13, ап. Д" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300406", Address = "ул. Петрохан № 98, ет.13, ап. Е" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300407", Address = "ул. Петрохан № 98, ет.13, ап. Ж" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300408", Address = "ул. Петрохан № 98, ет.13, ап. З" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300409", Address = "ул. Петрохан № 98, ет.13, ап. И" });
            await this.dbContext.HeatEstates.AddAsync(new HeatEstate { AbNumber = "13000300410", Address = "ул. Петрохан № 98, ет.13, ап. К" });
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DebitorsSeedAsync()
        {
            if (this.dbContext.Debitors.Any())
            {
                return; 
            }

            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300401", EGN = "0101085201", FirstName = "Борис", MiddleName = "Ангелов", LastName = "Станчев" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300402", EGN = "0201085202", FirstName = "Иван", MiddleName = "Цонев", LastName = "Димитров" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300403", EGN = "0301085203", FirstName = "Георги", MiddleName = "Георгиев", LastName = "Гец" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300404", EGN = "0401085204", FirstName = "Стефан", MiddleName = "Ламбов", LastName = "Данаилов" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300405", EGN = "0501085205", FirstName = "Ален", MiddleName = "Ален", LastName = "Делон" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300406", EGN = "0601085206", FirstName = "Жан", MiddleName = "Пол", LastName = "Белмондо" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300407", EGN = "0701085207", FirstName = "Мария", MiddleName = "Вероника", LastName = "Чиконе - Мадона" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300408", EGN = "0801085208", FirstName = "Робърт", MiddleName = "Де", LastName = "Ниро" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300409", EGN = "0901085209", FirstName = "Борис", MiddleName = "Маклейн", LastName = "Уилис" });
            await this.dbContext.Debitors.AddAsync(new Debitor { AbNumber = "13000300410", EGN = "1001085210", FirstName = "Чък", MiddleName = "Борис", LastName = "Рейнджър" });
            await this.dbContext.SaveChangesAsync();
        }

        //public Task HeatEstate_DebitorSeedAsync()
        //{
            
        //}
    }
}
