using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public interface ICreateCourtTownService
    {
        //Task Create(string townName, string address);
        void Create(string townName, string address);
    }
}
