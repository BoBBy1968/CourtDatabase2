using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface IPaymentsService
    {
        IEnumerable<PaymentsAllViewModel> All();
    }
}
