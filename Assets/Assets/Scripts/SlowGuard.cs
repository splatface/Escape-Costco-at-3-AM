using UnityEngine;

public class SlowGuard : Guard

{
    void Awake()
    {
        _speed = 80f;
        _patrolDistance = 100f;
    }
}