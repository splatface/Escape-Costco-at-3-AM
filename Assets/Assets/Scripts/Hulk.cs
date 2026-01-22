using UnityEngine;

public class Hulk : ItemBase
{
    protected override void Start()
    {
        this.Name = "hulk";
        this.Description = "Attack +6 for 10 seconds";
        this.Type = "powerup";
        base.Start();
    }
}

