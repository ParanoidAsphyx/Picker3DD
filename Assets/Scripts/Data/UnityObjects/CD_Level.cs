using System.Collections.Generic;
using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Level", menuName = "Picker 3DD/CD_Level", order = 1)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> Levels = new List<LevelData>();
    }
}
