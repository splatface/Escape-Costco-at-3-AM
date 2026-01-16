using UnityEngine;

public class MinorAttackBuff : AttackBuff
{
    private void Awake()
    {
        _buff = 3;
        _duration = 5;
    }
}
