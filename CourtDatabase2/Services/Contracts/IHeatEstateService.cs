using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IHeatEstateService
    {
        Task Create(string abNumber, string address);
    }
}
