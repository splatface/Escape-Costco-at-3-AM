using UnityEngine;

public class MinorSpeedBuff : SpeedBuff
{
    private void Awake()
    {
        _price = 5;
        _powerUpName = "Minor Speed Buff";
        _buff = 5;
        _duration = 5;
    }
}
