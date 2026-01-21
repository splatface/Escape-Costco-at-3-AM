using UnityEngine;

public class MajorSpeedBuff : SpeedBuff
{
    private void Awake()
    {
        _price = 10;
        _powerUpName = "Flash";
        _buff = 8;
        _duration = 10;
    }
}
