using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainWindow>();
            serviceCollection.AddTransient<WindowLogin>();
            serviceCollection.AddTransient<WindowProducts>();
            serviceCollection.AddTransient<WindowMembers>();
            serviceCollection.AddTransient<WindowOrders>();
            serviceCollection.AddTransient<WindowInsertOrder>();
            serviceCollection.AddTransient<WindowReportStatistics>();

            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IMemberRepository, MemberRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            serviceCollection.AddScoped<PRN221_Assignment01Context>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider.GetRequiredService<WindowLogin>().Show();
        }
    }

}
