using Microsoft.AspNetCore.Identity;
using dotnet_authentication.Models;

namespace dotnet_authentication.Services
{
    public class EmailSender : IEmailSender<User>
    {
        public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            // For now, just return completed task since we're not actually sending emails
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            return Task.CompletedTask;
        }
    }
}