using BarnManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Services
{
    public class AnimalLifecycleService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<AnimalLifecycleService> _logger;
        private readonly IConfiguration _config;

        public AnimalLifecycleService(IServiceScopeFactory scopeFactory,
                                      ILogger<AnimalLifecycleService> logger,
                                      IConfiguration config)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var tick = _config.GetValue<int?>("Lifecycle:TickSeconds") ?? 10;
            var delay = TimeSpan.FromSeconds(tick);

            _logger.LogInformation("AnimalLifecycleService started. Tick={Tick}s", tick);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                   
                    var animals = await db.Animals.ToListAsync(stoppingToken);
                    foreach (var a in animals)
                    {
                        if (!a.IsAlive) continue;
                        a.Age += 1; 
                        if (a.Age >= a.Lifespan)
                        {
                           
                            db.Animals.Remove(a); 
                            _logger.LogInformation(
                                "Animal removed (lifespan ended). Id={Id} Species={S} Age={Age}/{Life}",
                                a.Id, a.Species, a.Age, a.Lifespan);
                        }
                    }
                    await db.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Animal lifecycle tick failed");
                }

                try { await Task.Delay(delay, stoppingToken); } catch { /* ignore */ }
            }
        }
    }
}
