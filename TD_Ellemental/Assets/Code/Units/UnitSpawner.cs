using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private LevelConfig m_levelConfig;

    private float m_nextSpawnTime = 0;
    private int m_currentWave = 0;
    private int m_spawnedAmount = 0;

    public WaveConfig CurrentWave
    {
        get { return m_levelConfig.Waves[m_currentWave]; }
    }
    public UnitEnemyConfig CurrentSpawnUnit
    {
        get { return CurrentWave.EnemyUnit; }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_nextSpawnTime <= Time.time)
        {
            m_nextSpawnTime = Time.time + CurrentWave.SpawnCooldawn;
            Spawn();
        }
    }

    protected void Spawn()
    {
        UnitEnemy newUnit = Instantiate<UnitEnemy>( CurrentSpawnUnit.Prefab, transform.position, transform.rotation);
        ++m_spawnedAmount;
    }

    public void NextWave()
    {
        ++m_currentWave;
        m_nextSpawnTime += CurrentWave.StartSecondsDelay;
    }
}
