using UnityEngine;

public class MajorAttackBuff : AttackBuff
{
    private void Awake()
    {
        _price = 10;
        _powerUpName = "Major Attack Buff";
        _buff = 6;
        _duration = 10;
    }
}
