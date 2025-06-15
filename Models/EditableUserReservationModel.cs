using backend.Models;
using System.Collections.Generic;
namespace Models // ou a pasta que preferir
{
    public class EditableUserReservationModel
    {
        // Contém os dados do quarto (Nome, Descrição, ImgURL, etc.)
        public Room RoomData { get; set; }

        // Contém os dados da reserva específica do usuário (ID, StartDate, EndDate)
        public RoomReservation UserReservation { get; set; }

        // Contém APENAS os períodos de conflito, ou seja,
        // todas as outras reservas para este quarto, EXCLUINDO a do próprio usuário.
        public IEnumerable<Period> ConflictingPeriods { get; set; }
    }
}