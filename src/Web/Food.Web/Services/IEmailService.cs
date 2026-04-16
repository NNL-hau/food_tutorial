using System.Threading.Tasks;

namespace Food.Web.Services
{
    public interface IEmailService
    {
        Task SendOrderConfirmationEmailAsync(string email, string fullName, string orderId, decimal totalPrice);
    }
}
