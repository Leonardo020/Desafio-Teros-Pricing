using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using OpenBanking.Participants.Application.Jobs;
using OpenBanking.Participants.Application.Services;
using OpenBanking.Participants.Domain.Interfaces.Clients;
using OpenBanking.Participants.Domain.Interfaces.Repositories;
using OpenBanking.Participants.Domain.Interfaces.Services;
using OpenBanking.Participants.Infrastructure.Data.Repositories;
using Quartz;
using Refit;

namespace OpenBanking.Participants.Infrastructure.IOC
{
    public static class ConfigurationIOC
    {
        public static IServiceCollection AddCronJobs(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                var jobKey = new JobKey("ExtractionJob");
                q.AddJob<ExtractionJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("ExtractionJob-trigger")
                    //configured cron to run the job every hour 
                    .WithCronSchedule("0 0 * ? * * *"));
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }

        public static IServiceCollection AddDynamoDBClient(this IServiceCollection services)
        {
            services.AddTransient<IAmazonDynamoDB>((ctx) => new AmazonDynamoDBClient(
                awsAccessKeyId: "local", 
                awsSecretAccessKey: "local",
                clientConfig: new AmazonDynamoDBConfig()
                {
                    RegionEndpoint = RegionEndpoint.USEast1,
                    ServiceURL = Environment.GetEnvironmentVariable("DYNAMO_DB_SERVICE_URL"),
                })
            );

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IParticipantRepository, ParticipantRepository>();

            return services;
        }

        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddRefitClient<IOpenBankingClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("OPEN_BANKING_URI")!));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IParticipantService, ParticipantService>();

            return services;
        }
    }
}
