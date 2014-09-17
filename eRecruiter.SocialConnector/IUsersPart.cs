using System.Threading.Tasks;

namespace eRecruiter.SocialConnector
{
    public interface IUsersPart
    {
        Task<IProfile> ForMe();
    }
}
