using UnityEngine;

public class MajorAttackBuff : AttackBuff
{
    private void Awake()
    {
        _price = 10;
        _powerUpName = "Hulk";
        _buff = 6;
        _duration = 10;
    }
}
