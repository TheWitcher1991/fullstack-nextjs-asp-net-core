using System.ComponentModel.DataAnnotations;

namespace backend.Communication.Contracts
{
    public record CreateFavoriteDto(
       [Required] Guid Book
   );
}
