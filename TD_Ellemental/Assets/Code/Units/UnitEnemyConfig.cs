using UnityEngine;

//[CreateAssetMenu(fileName = "EnemyUnit", menuName = "TD/EnemyUnit")]
[System.Serializable]
public class UnitEnemyConfig //: ScriptableObject
{
    public UnitEnemy Prefab;//public GameObject Prefab;
    public int HP;
    public float MoveSpeed;
    public float Defense;
    public float HpRegenValue;
    public float HpRegenDelay;
    public int CoinsAward;
}
