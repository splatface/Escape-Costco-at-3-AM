using UnityEngine;

public class GunItem : ItemBase
{
    protected override void Start()
    {
        this.Name = "gun";
        this.Description = "Use this to shoot the manager.";
        this.Type = "weapon";
        base.Start();
    }
}
