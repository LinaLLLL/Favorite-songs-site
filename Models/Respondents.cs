using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavoriteSongs.Models
{
    public class Respondents
    {
        [Key]
        public int Id { get; set; }
        [Column("Last_name")]
        public string LastName { get; set; }
        public string Gender { get; set; }  // М или Ж
        public int Age { get; set; }
        [Column("Age_category")]
        public AgeCategory AgeCategory { get; set; }  // Категория по возрасту

        public List<SurveyResults> SurveyResults { get; set; }  // Связь с таблицей голосов
    }
    public enum AgeCategory
    {
        Under20,  // Моложе 20 лет
        Over20,   // Старше 20 лет
        Over40    // Старше 40 лет
    }
}
