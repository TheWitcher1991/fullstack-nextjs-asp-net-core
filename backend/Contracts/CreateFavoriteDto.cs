using System.ComponentModel.DataAnnotations;

namespace backend.Contracts
{
    public record CreateFavoriteDto(
       [Required] Guid Book
   );
}
