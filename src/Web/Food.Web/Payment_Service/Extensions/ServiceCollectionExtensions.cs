using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment_Service.Configuration;
using Payment_Service.Models;
using Payment_Service.Services;

namespace Payment_Service.Extensions
{
    /// <summary>
    /// Extension methods d? dang ký Payment Service vào DI container
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Ðang ký Payment Service v?i c?u hình t? appsettings.json
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPaymentService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Ðang ký settings
            services.Configure<PaymentSettings>(configuration.GetSection("Payment"));
            services.Configure<MoMoSettings>(configuration.GetSection("Payment:MoMo"));
            services.Configure<VNPaySettings>(configuration.GetSection("Payment:VNPay"));

            // Ðang ký HttpClient
            services.AddHttpClient();

            // Ðang ký services
            services.AddScoped<IMoMoService, MoMoService>();
            services.AddScoped<IVNPayService, VNPayService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }

        /// <summary>
        /// Ðang ký Payment Service v?i c?u hình custom
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configureOptions">Action d? c?u hình settings</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPaymentService(
            this IServiceCollection services,
            Action<PaymentSettings> configureOptions)
        {
            // Ðang ký settings v?i custom configuration
            services.Configure(configureOptions);

            // Ðang ký HttpClient
            services.AddHttpClient();

            // Ðang ký services
            services.AddScoped<IMoMoService, MoMoService>();
            services.AddScoped<IVNPayService, VNPayService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }

        /// <summary>
        /// Ðang ký ch? MoMo Service
        /// </summary>
        public static IServiceCollection AddMoMoPayment(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MoMoSettings>(configuration.GetSection("Payment:MoMo"));
            services.AddHttpClient();
            services.AddScoped<IMoMoService, MoMoService>();
            return services;
        }

        /// <summary>
        /// Ðang ký ch? VNPay Service
        /// </summary>
        public static IServiceCollection AddVNPayPayment(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<VNPaySettings>(configuration.GetSection("Payment:VNPay"));
            services.AddScoped<IVNPayService, VNPayService>();
            return services;
        }
    }
}
