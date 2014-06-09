using UnityEngine;
using System.Collections;

public class ShootoutManager :
    MonoBehaviour
{
    #region Fields
    public ShootoutTarget Left;
    public ShootoutTarget Right;

    public float CooldownMin;
    public float CooldownMax;
    public float SpeedMin;
    public float SpeedMax;

    public float cooldown;
    #endregion
    
    #region Methods
    void Start()
    {
        Left.Speed = Random.Range(SpeedMin, SpeedMax);
        Right.Speed = -Random.Range(SpeedMin, SpeedMax);
        cooldown = Random.Range(CooldownMin, CooldownMax);
    }

    void Update()
    {
        if (Left.Speed == 0 && Right.Speed == 0)
        {
            if (cooldown <= 0)
            {
                Left.Speed = Random.Range(SpeedMin, SpeedMax);
                Right.Speed = -Random.Range(SpeedMin, SpeedMax);
                cooldown = Random.Range(CooldownMin, CooldownMax);
            }
            else
            {
                cooldown -= Time.fixedDeltaTime;
            }
        }
    }
    #endregion

}

