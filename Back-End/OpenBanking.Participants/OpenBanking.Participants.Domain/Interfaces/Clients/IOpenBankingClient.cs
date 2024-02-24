using OpenBanking.Participants.Domain.Payloads;
using Refit;

namespace OpenBanking.Participants.Domain.Interfaces.Clients
{
    public interface IOpenBankingClient
    {
        [Get("/participants")]
        Task<IEnumerable<OpenBankingParticipantResponse>> GetParticipants();
    }
}
