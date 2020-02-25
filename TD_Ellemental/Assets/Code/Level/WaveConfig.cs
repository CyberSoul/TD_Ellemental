using UnityEngine;


//[CreateAssetMenu(fileName = "Level", menuName = "TD/Wave")]
[System.Serializable]
public class WaveConfig //: ScriptableObject
{
    public int StartSecondsDelay;
    public int UnitsAmount;
    public float SpawnCooldawn;
    public UnitEnemyConfig EnemyUnit;

    public int CoinsAward;
}
