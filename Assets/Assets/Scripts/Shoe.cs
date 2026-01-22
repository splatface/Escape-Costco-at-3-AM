using UnityEngine;

public class Shoe : ItemBase
{
    protected override void Start()
    {
        this.Name = "shoes";
        this.Description = "Speed +5 for 5 seconds";
        this.Type = "powerup";
        base.Start();
    }
}
