namespace Logic
{
	public interface IRecommendationFilter
	{
		List<Album> GetFilteredAlbum(User user);
	}
}
