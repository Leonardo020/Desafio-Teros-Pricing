using Amazon.DynamoDBv2.DataModel;

namespace OpenBanking.Participants.Domain.Entities
{
    [DynamoDBTable("tb_participants")]
    public class Participant
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string DiscoveryUrl { get; set; } = string.Empty;
    }
}
