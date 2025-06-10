using WebApplication1.DTO;
namespace WebApplication1.Services;
public interface IRacersService
{
    Task<GetRacerDTO> Get(int id);
}