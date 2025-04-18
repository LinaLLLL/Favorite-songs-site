namespace FavoriteSongs.Models
{
    public class SongWithVotes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int VoteCount { get; set; }
    }
}
