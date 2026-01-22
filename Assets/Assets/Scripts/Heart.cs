using UnityEngine;

public class Heart : ItemBase
{
    protected override void Start()
    {
        this.Name = "heart";
        this.Description = "Health +10";
        this.Type = "powerup";
        base.Start();
    }
}

