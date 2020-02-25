using UnityEngine;

public class UnitEnemy : MonoBehaviour
{
    protected UnitEnemyConfig m_config;

    protected float m_currentHP;
    protected float m_nextRegenTime = 0;
    //Effecets: Debuffs, Buffs

    public float HpRegenDelayTime
    {
        get { return m_config.HpRegenDelay; }
    }
    public bool IsFullHP
    {
        get { return m_currentHP == m_config.HP; }
    }
    public float CurrentHP
    {
        get { return m_currentHP; }
        set { m_currentHP = Mathf.Min(m_config.HP, value); }
    }

    public void ApplyConfig( UnitEnemyConfig a_config )
    {
        m_config = a_config;

        m_currentHP = m_config.HP;
        m_nextRegenTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsFullHP && m_nextRegenTime <= Time.time )
        {
            m_nextRegenTime = Time.time + HpRegenDelayTime;
            CurrentHP += m_config.HpRegenValue;
        }
    }
}
