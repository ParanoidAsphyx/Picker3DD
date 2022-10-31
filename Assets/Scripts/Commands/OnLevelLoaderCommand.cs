using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnLevelLoaderCommand : MonoBehaviour
{
    public class OnLevelLoaderCommand : ICommand
    {
        private Transform _levelHolder;

        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public OnLevelDestroyerCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        public void Execute()
        {

        }

        public void Execute(int levelID)
        {
            Object.Instantiate(original: Resources.Load<GameObject>(path: $"Prefabs/LevelPrefabs/level{levelID}"), _levelHolder);
        }
    }
}
