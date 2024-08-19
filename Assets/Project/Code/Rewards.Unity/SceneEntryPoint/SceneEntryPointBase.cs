using Rewards.Container;
using UnityEngine;

namespace Rewards.Unity.SceneEntryPoint
{
    public abstract class SceneEntryPointBase : MonoBehaviour
    {
        public abstract void Enter(IContainer container);
    }
}