using UnityEngine;
using System.Collections;

public abstract class SpeedBuff : PowerUpEffect
{
    private void Awake()
    {
        
    }

    // public void Apply(GameObject target)
    // {
    //     PlayerMovement player = target.GetComponent<PlayerMovement>();

    //     if (player != null)
    //     {
    //         player.StartCoroutine(ApplyBuff(player));
    //     }
    // }

    // private IEnumerator ApplyBuff(PlayerMovement player)
    // {
    //     float originalSpeed = player.GetMoveSpeed();

    //     float buffedSpeed = originalSpeed * _buff;

    //     player.SetMoveSpeed(buffedSpeed);

    //     yield return new WaitForSeconds(_duration);

    //     player.SetMoveSpeed(originalSpeed);
    // }
}
