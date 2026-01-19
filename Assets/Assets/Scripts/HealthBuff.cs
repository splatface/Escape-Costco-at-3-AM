using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerUpEffect 
{
    private void Awake()
    {
        _price = 25;
        _powerUpName = "Health Buff";
        _buff = 10;
        _duration = 100;
    }
    // public override void Apply(GameObject target)
    // {
    //         PlayerMovement player = target.GetComponent<PlayerMovement>();

    //     if (player != null)
    //     {
    //         int newHealth = player.GetHealth() + 30;
    //         player.SetHealth(newHealth); 
    //     }
    // }
}
