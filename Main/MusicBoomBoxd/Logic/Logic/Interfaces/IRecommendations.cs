namespace Logic
{
    public interface IRecommendations
    {
        List<Album> GetRecommendedAlbums(User user, List<IRecommendationFilter> _filters);

	}
}
