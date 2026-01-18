using UnityEngine;

public class MinorAttackBuff : AttackBuff
{
    private void Awake()
    {
        _price = 5;
        _powerUpName = "Minor Attack Buff";
        _buff = 3;
        _duration = 5;
    }
}
