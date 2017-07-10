using RestAPI.Core.EntityLayer;
using RestAPI.ViewModels;

namespace RestAPI.Extensions
{
    public static class TransactionViewModelMapper
    {
        public static TransactionViewModel ToViewModel(this Transaction entity)
        {
            return entity == null
                ? null
                : new TransactionViewModel
                {
                    TransactionId = entity.TransactionId,
                    TransactionDate = entity.TransactionDate,
                    Description = entity.Description,
                    TransactionAmount = entity.TransactionAmount,
                    CreatedDate = entity.CreatedDate,
                    ModifiedDate = entity.ModifiedDate,
                    CurrencyCode = entity.CurrencyCode,
                    Merchant = entity.Merchant
                };
        }

        public static Transaction ToEntity(this TransactionViewModel viewModel)
        {
            return viewModel == null ? null : new Transaction
            {
                TransactionId = viewModel.TransactionId,
                TransactionDate = viewModel.TransactionDate,
                Description = viewModel.Description,
                TransactionAmount = viewModel.TransactionAmount,
                CreatedDate = viewModel.CreatedDate,
                ModifiedDate = viewModel.ModifiedDate,
                CurrencyCode = viewModel.CurrencyCode,
                Merchant = viewModel.Merchant
            };
        }
    }
}
