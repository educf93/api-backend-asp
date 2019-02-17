using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApiGtt.Models;


    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(20));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var optionsBuild = new DbContextOptionsBuilder<ApiGtt.Models.AppDBContext>();

            optionsBuild.UseNpgsql("Host=192.168.99.100;Port=5432;Username=postgres;Password=example;Database=ApiGtt;");


            using (var context = new ApiGtt.Models.AppDBContext(optionsBuild.Options))
            {
                context.Certificates.Load();
                foreach (var certifcate in context.Certificates.Local)
                {
                    
                    var monthsAdded = 1;
                    var expireDateCert = certifcate.expireDate.Date;
                    var expireDateNow = DateTime.Now.AddMonths(monthsAdded).Date;
                    var noticed = certifcate.notice;
                    
                    if (expireDateCert == expireDateNow && noticed != true)
                    {
                    
;                       Certificates certs = context.Certificates.Find(certifcate.id);
                        certs.notice = true;
                        context.SaveChanges();
                    }
                }

            }
            _logger.LogInformation("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
