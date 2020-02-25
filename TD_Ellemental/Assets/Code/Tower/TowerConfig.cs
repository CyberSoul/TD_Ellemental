using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "TD/Tower")]
public class TowerConfig : ScriptableObject
{
    public string TowerName;
    public string Decription;

    public Texture2D Icon; // Or maybe path
    public GameObject Prefab;
    public EllementType Ellement = EllementType.None;

    public int Damage;
    public float AttackRate;
    public float AttackRadius;

    public int CoinsPrice;
}
