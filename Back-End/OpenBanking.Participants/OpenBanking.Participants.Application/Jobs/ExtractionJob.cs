using OpenBanking.Participants.Domain.Entities;
using OpenBanking.Participants.Domain.Interfaces.Clients;
using OpenBanking.Participants.Domain.Interfaces.Repositories;
using Quartz;
using Refit;

namespace OpenBanking.Participants.Application.Jobs
{
    public class ExtractionJob(IParticipantRepository participantRepository, IOpenBankingClient openBankingClient) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine($"Execution time: {DateTime.Now.ToLongTimeString()}");
                var participantsResponse = await openBankingClient.GetParticipants();

                await participantRepository.AddRange(participantsResponse.Select(participantResponse => (Participant)participantResponse));
            }
            catch (ApiException e)
            {
                Console.WriteLine($"Error on get participants data: {e.StatusCode}: {e.Content}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error on job execution: {e.Message}");
                throw;
            }

        }
    }
}
