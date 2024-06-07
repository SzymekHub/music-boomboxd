namespace Infrastructure
{
    public interface IProfileRepository
    {
        Result InsertProfile(ProfileDTO profileDTO);
        Result AddProfileCritic(ProfileDTO profileDTO);
        Result AddProfileMusician(ProfileDTO profileDTO);
        double GetBalance(string userName);
        Result AddToUserBalance(int profileId, double amount);
		int GetProfileIDByUsername(string userName);
    }
}