using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProfileMapper
    {
        public static ProfileDTO ConvertToProfileDTO(Profile profile)
        {
            ProfileDTO profileDTO = new ProfileDTO();
            profileDTO.ProfileID = profile.ProfileID;
            profileDTO.UserID = profile.UserID;
            profileDTO.User_Balance = profile.User_Balance;

            return profileDTO;
        }
    }
}
