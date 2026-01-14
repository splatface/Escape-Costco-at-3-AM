using UnityEngine;
using System.Collections;

public abstract class SpeedBuff : PowerUpEffect
{
    protected float speedMultiplier;
    protected float duration;

    public override void Apply(GameObject target)
    {
        PlayerMovement player = target.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.StartCoroutine(ApplyBuff(player));
        }
    }

    private IEnumerator ApplyBuff(PlayerMovement player)
    {
        float originalSpeed = player.GetMoveSpeed();

        float buffedSpeed = originalSpeed * speedMultiplier;

        player.SetMoveSpeed(buffedSpeed);

        yield return new WaitForSeconds(duration);

        player.SetMoveSpeed(originalSpeed);
    }
}
