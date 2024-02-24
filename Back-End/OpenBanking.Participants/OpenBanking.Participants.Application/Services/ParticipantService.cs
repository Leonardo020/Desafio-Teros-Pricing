using OpenBanking.Participants.Domain.Entities;
using OpenBanking.Participants.Domain.Interfaces.Repositories;
using OpenBanking.Participants.Domain.Interfaces.Services;

namespace OpenBanking.Participants.Application.Services
{
    public class ParticipantService(IParticipantRepository participantRepository) : IParticipantService
    {
        public async Task<IEnumerable<Participant>> Get()
            => await participantRepository.Get();
    }
}
