using OpenBanking.Participants.Domain.Entities;

namespace OpenBanking.Participants.Domain.Interfaces.Repositories
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> Get();
        Task AddRange(IEnumerable<Participant> participants);
    }
}
