using UnityEngine;

public class Muscle : ItemBase
{
    protected override void Start()
    {
        this.Name = "muscle";
        this.Description = "Attack +3 for 5 seconds";
        this.Type = "powerup";
        base.Start();
    }
}
