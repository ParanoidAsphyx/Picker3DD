using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_Level", menuName = "Picker3DD/CD_Level")]
public class CD_Level : ScriptableObject
{
    public List<LevelData> Levels = new List<LevelData>();
}
