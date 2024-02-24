using OpenBanking.Participants.Domain.Entities;

namespace OpenBanking.Participants.Domain.Interfaces.Services
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> Get();
    }
}
