using ManagementSystem.Common.Exceptions;
using ManagementSystem.Repository.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManagementSystem.Application.Service.BackgroundServices;

public class DeleteUserBackgroundService(IServiceScopeFactory scopeFactory) : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var userToDelete = _unitOfWork.UserRepository.GetAll().Where(u => u.CreatedDate == null && !u.IsDeleted).ToList();
                if (userToDelete.Count != 0)
                {
                    foreach (var user in userToDelete)
                    {
                        user.IsDeleted = true;
                        user.DeletedDate = DateTime.Now;
                        user.DeletedBy = 1;
                    }
                    await _unitOfWork.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }


            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
