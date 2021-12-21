using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1EffectEvent : MonoBehaviour
{
    private DamageObject senderDamage;


    void Start()
    {
        
    }

    public void InitData(DamageObject damage)
    {
        senderDamage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAI enemyAI = other.GetComponent<EnemyAI>();
        if (enemyAI != null && senderDamage != null)
        {
            enemyAI.Hit(senderDamage);

        }
    }

}
