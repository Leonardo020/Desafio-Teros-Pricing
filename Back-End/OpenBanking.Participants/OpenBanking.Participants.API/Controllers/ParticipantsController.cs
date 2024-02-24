using Microsoft.AspNetCore.Mvc;
using OpenBanking.Participants.Domain.Entities;
using OpenBanking.Participants.Domain.Interfaces.Services;
using OpenBanking.Participants.Domain.Payloads;

namespace OpenBanking.Participants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController(IParticipantService participantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Participant> participants = await participantService.Get();

                return Ok(new GenericResponse<IEnumerable<Participant>>(
                    success: true,
                    message: "Participants loaded successfully",
                    data: participants)
                );
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResponse<string>(
                    success: false,
                    message: "Failed on load participants",
                    data: e.Message)
                );
            }
        }
    }
}
