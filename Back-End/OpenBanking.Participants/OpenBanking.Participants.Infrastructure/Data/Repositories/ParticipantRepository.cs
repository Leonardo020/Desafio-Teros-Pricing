using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using OpenBanking.Participants.Domain.Entities;
using OpenBanking.Participants.Domain.Interfaces.Repositories;

namespace OpenBanking.Participants.Infrastructure.Data.Repositories
{
    public class ParticipantRepository(IAmazonDynamoDB client) : IParticipantRepository
    {
        private readonly DynamoDBContext _ctx = new(client);

        public async Task<IEnumerable<Participant>> Get()
        {
            var response = _ctx.FromScanAsync<Participant>(new ScanOperationConfig());
            return await response.GetRemainingAsync();    
        }

        public async Task AddRange(IEnumerable<Participant> participants)
        {
            var batch = _ctx.CreateBatchWrite<Participant>();
            batch.AddPutItems(participants);

            await batch.ExecuteAsync();
        }
    }
}
