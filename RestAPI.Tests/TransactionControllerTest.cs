using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers;
using RestAPI.ViewModels;
using Xunit;

namespace RestAPI.Tests
{
    public class TransactionControllerTest
    {
        [Fact] public async Task Transaction_GetAllTransactionsAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);

                // Act
                var response = await controller.GetAllTransactions() as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.Value as IList<TransactionViewModel>;

                    Assert.NotNull(value);
                    Assert.Equal(value.Count, 3);
                }
            }
        }

        [Fact]
        public async Task Transaction_GetTransactionAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);
                var id = 3;

                // Act
                var response = await controller.GetTransaction(id) as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.Value as TransactionViewModel;

                    Assert.NotNull(value);
                    Assert.Equal(value.TransactionId, 3);
                }
            }
        }

        [Fact]
        public async Task Transaction_GetNonExistingTransactionAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);
                var id = 0;

                // Act
                var response = await controller.GetTransaction(id) as ObjectResult;

                // Assert
                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Transaction_CreateTransactionAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);

                var viewModel = new TransactionViewModel
                {
                    Description = "Test Transaction10",
                    TransactionDate = DateTime.Now,
                    TransactionAmount = 240,
                    CreatedDate = DateTime.Now,
                    CurrencyCode = "INR",
                    Merchant = "WesternUnion",
                    ModifiedDate = DateTime.Now
                };

                // Act
                var response = await controller.CreateTransaction(viewModel) as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.StatusCode;
                    Assert.Equal(value , 201);
                }
            }
        }

        [Fact]
        public async Task Transaction_UpdateTransactionAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);

                var id = 2;

                var viewModel = new TransactionViewModel
                {
                    Description = "New Transaction test II",
                    TransactionAmount = 100,
                    TransactionId = id,
                    TransactionDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    Merchant = "PayPal",
                    CurrencyCode = "GBP"
                };

                // Act
                var response = await controller.UpdateTransaction(id, viewModel) as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.StatusCode;

                    Assert.Equal(value, 200);
                }
            }
        }

        [Fact]
        public async Task Transaction_DeleteTransactionAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);

                var id = 1;

                // Act
                var response = await controller.DeleteTransaction(id) as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.StatusCode;

                    Assert.Equal(value, 200);
                }
            }
        }

        [Fact]
        public async Task Transaction_DeleteTransactionWithNonExistingIdAsync()
        {
            using (var repository = RepositoryMocker.MoneyBoxRepository)
            {
                // Arrange
                var controller = new TransactionController(repository);

                var id = -1;

                // Act
                var response = await controller.DeleteTransaction(id) as ObjectResult;

                // Assert
                if (response != null)
                {
                    var value = response.StatusCode;

                    Assert.Equal(value, 400);
                }
            }
        }
    }
}
