using System.Collections.Generic;
using Rewards.Item;
using Rewards.Resource;
using Rewards.Storage.Profile.Data;
using Rewards.Storage.SaveStrategy;
using Rewards.Storage.SaveStrategy.FileOperations;
using UnityEngine;

namespace Rewards.Unity.Game
{
    public class EntryPoint : MonoBehaviour
    {
        private string _saveDataPath;
        private IFileOperations _fileOperations;
        private ISaveStrategy _saveStrategy;

        private void Awake()
        {
            _saveDataPath = Application.persistentDataPath;
            _fileOperations = new FileOperations();
            _saveStrategy = new JsonFileStrategy(_fileOperations, _saveDataPath);

            var profile = new ProfileData
            {
                Resources = new Dictionary<ResourceType, int>
                {
                    { ResourceType.Tickets, 3 },
                    { ResourceType.HardCurrency, 2 },
                    { ResourceType.SoftCurrency, 1 }
                },
                Items = new List<ItemType>
                {
                    ItemType.Weapon_AK,
                }
            };
            _saveStrategy.Save(profile, ProfileSavedEventManager);
        }

        private void ProfileSavedEventManager()
        {
            Debug.Log(message: "Profile saved");
        }
    }
}