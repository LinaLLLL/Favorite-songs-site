using System.ComponentModel.DataAnnotations;

namespace FavoriteSongs.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }          // Идентификатор
        public string Title { get; set; }    // Название песни
        public string Artist { get; set; }   // Исполнитель
        public List<SurveyResults> SurveyResults { get; set; }  // Связь с таблицей голосов
       
    }
}
