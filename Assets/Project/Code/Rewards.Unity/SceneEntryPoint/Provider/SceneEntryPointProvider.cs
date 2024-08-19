using System.Collections.Generic;
using Rewards.Exceptions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rewards.Unity.SceneEntryPoint.Provider
{
    public class SceneEntryPointProvider : ISceneEntryPointProvider
    {
        private readonly List<GameObject> _rootObjects = new(10);
        
        public TEntryPoint Find<TEntryPoint>() where TEntryPoint : Component
        {
            var activeScene = SceneManager.GetActiveScene();
            activeScene.GetRootGameObjects(_rootObjects);

            foreach (var currentObject in _rootObjects)
            {
                var entryPoint = currentObject.GetComponent<TEntryPoint>();
                
                if (entryPoint == null)
                {
                    continue;
                }

                return entryPoint;
            }
            
            throw new ElementNotFountException($"Can't find object of type {typeof(TEntryPoint).Name}");
        }
    }
}