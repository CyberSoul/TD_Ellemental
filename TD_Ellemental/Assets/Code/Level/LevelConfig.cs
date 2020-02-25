using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "TD/Level")]
public class LevelConfig : ScriptableObject
{
    public WaveConfig[] Waves;
}
