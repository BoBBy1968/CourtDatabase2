using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public interface ISeederService
    {
        Task DebitorsSeedAsync();
        
        Task HeatEstateSeedAsync();

        //Task HeatEstate_DebitorSeedAsync();
    }
}
