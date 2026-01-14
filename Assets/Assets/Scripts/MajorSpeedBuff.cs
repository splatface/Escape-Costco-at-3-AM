using UnityEngine;

public class MajorSpeedBuff : SpeedBuff
{
    private void Awake()
    {
        speedMultiplier = 1.75f;
        duration = 40f;
    }
}
