using UnityEngine;

public class MajorAttackBuff : AttackBuff
{
    private void Awake()
    {
        _buff = 6;
        _duration = 10;
    }
}
