using CourtDatabase2.Data;
using CourtDatabase2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public class SeedServiceDebitors : IDebitorsSeeder
    {
        private readonly ApplicationDbContext dbContext;

        public SeedServiceDebitors(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void DebitorsSeed()
        {
            if (this.dbContext.Debitors.Any())
            {
                return;
            }

            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300401", EGN = "0101085201", FirstName = "Борис", MiddleName = "Ангелов", LastName = "Станчев" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300402", EGN = "0201085202", FirstName = "Иван", MiddleName = "Цонев", LastName = "Димитров" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300403", EGN = "0301085203", FirstName = "Георги", MiddleName = "Георгиев", LastName = "Гец" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300404", EGN = "0401085204", FirstName = "Стефан", MiddleName = "Ламбов", LastName = "Данаилов" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300405", EGN = "0501085205", FirstName = "Ален", MiddleName = "Ален", LastName = "Делон" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300406", EGN = "0601085206", FirstName = "Жан", MiddleName = "Пол", LastName = "Белмондо" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300407", EGN = "0701085207", FirstName = "Мария", MiddleName = "Вероника", LastName = "Чиконе - Мадона" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300408", EGN = "0801085208", FirstName = "Робърт", MiddleName = "Де", LastName = "Ниро" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300409", EGN = "0901085209", FirstName = "Борис", MiddleName = "Маклейн", LastName = "Уилис" });
            this.dbContext.Debitors.Add(new Debitor { AbNumber = "13000300410", EGN = "1001085210", FirstName = "Чък", MiddleName = "Борис", LastName = "Рейнджър" });
            this.dbContext.SaveChanges();
        }
    }
}
