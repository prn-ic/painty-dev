using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;
using EventBus.Entities.Users;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Communication.BusinessLayer.MassTransit.Consumers
{
    public class AuthCreateModelConsumer : IConsumer<AuthCreateModel>
    {
        private readonly ILogger<AuthCreateModelConsumer> _logger;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        public AuthCreateModelConsumer(ILogger<AuthCreateModelConsumer> logger,
            IUserService userService, IUserRoleService userRoleService)
        {
            _logger = logger;
            _userService = userService;
            _userRoleService = userRoleService;
        }
        public async Task Consume(ConsumeContext<AuthCreateModel> context)
        {
            UserRole? role = await _userRoleService.GetByNameAsync(context.Message.RoleName!);
            User user = new User(context.Message.Name!, "", role!);

            await _userService.CreateAsync(user);

            _logger.LogInformation("[+] Succesfully get message. {0}:{1} has been added", user.Id, user.Name);
        }
    }
}
