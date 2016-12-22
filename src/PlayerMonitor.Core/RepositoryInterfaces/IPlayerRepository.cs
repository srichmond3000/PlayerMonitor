using System.Collections.Generic;

namespace PlayerMonitor.Core.RepositoryInterfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<PlayerModel> GetAllPlayers();
    }
}
