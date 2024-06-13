namespace Logic
{
	public class Recommendations: IRecommendations
	{
		public List<Album> GetRecommendedAlbums(User user, List<IRecommendationFilter> _filters) 
		{
			List<Album> reccoAlbum = new List<Album>();

			foreach (var filter in _filters)
			{
				reccoAlbum.AddRange(filter.GetFilteredAlbum(user));
			}

			reccoAlbum = reccoAlbum.Distinct().ToList();

			return reccoAlbum;
		}
	}
}
