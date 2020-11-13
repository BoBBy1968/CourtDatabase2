using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ISeederService
    {
        Task DebitorsSeedAsync();
        
        Task HeatEstateSeedAsync();

        //Task HeatEstate_DebitorSeedAsync();
    }
}
