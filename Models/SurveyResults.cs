using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavoriteSongs.Models
{
    public class SurveyResults
    {
        [Key]
        public int Id { get; set; }
        [Column("Respondent_id")]
        public int RespondentId { get; set; }
        [Column("Song_id")]
        public int SongId { get; set; }
        public int Rank { get; set; }  // Ранг от 1 до 5

        public Respondents Respondent { get; set; }
        public Song Song { get; set; }
    }
}
