using UnityEngine;

public class GasItem : ItemBase
{
    protected override void Start()
    {
        this.Name = "gas";
        this.Description = "Release this to kill the assistant.";
        this.Type = "weapon";
        base.Start();
    }
}
