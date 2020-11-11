using CourtDatabase2.ViewModels;

namespace CourtDatabase2.Services
{
    public interface ILawCaseService
    {
        void Create(LawCaseInputModel model);
    }
}
