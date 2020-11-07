using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public interface IHeatEstateService
    {
        Task Create(string abNumber, string address);
    }
}
