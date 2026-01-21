using UnityEngine;

public class MinorSpeedBuff : SpeedBuff
{
    private void Awake()
    {
        _price = 5;
        _powerUpName = "Shoe";
        _buff = 5;
        _duration = 5;
    }
}
