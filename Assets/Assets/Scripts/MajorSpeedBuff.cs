using UnityEngine;

public class MajorSpeedBuff : SpeedBuff
{
    private void Awake()
    {
        _price = 10;
        _powerUpName = "Major Speed Buff";
        _buff = 8;
        _duration = 10;
    }
}
