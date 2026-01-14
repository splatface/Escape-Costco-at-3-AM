using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerUpEffect 
{
    public float amount;
    public override void Apply(GameObject target)
    {
            PlayerMovement player = target.GetComponent<PlayerMovement>();

        if (player != null)
        {
            int newHealth = player.GetHealth() + 30;
            player.SetHealth(newHealth); 
        }
    }
}
