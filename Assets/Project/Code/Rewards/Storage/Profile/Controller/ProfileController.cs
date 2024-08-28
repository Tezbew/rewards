using Rewards.Storage.Profile.Data;
using Rewards.Storage.SaveStrategy;

namespace Rewards.Storage.Profile.Controller
{
    public class ProfileController : IProfileController
    {
        private readonly ISaveStrategy _saveStrategy;
        private ProfileData _data;

        public ProfileController(ISaveStrategy saveStrategy)
        {
            _saveStrategy = saveStrategy;
        }

        public void Initialize()
        {
            if (_saveStrategy.TryLoad<ProfileData>(DataLoaded))
            {
                return;
            }

            var instance = new ProfileData();
            DataLoaded(instance);
        }

        private void Save()
        {
            _saveStrategy.Save(_data, SaveFinished);
        }

        private void DataLoaded(ProfileData data)
        {
            _data = data;
        }

        private void SaveFinished()
        {
        }
    }
}