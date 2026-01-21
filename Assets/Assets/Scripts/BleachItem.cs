using UnityEngine;

public class BleachItem : ItemBase
{
    protected override void Start()
    {
        this.Name = "bleach";
        this.Description = "One of the ingredients needed to create toxic gas.";
        this.Type = "interactable";
        base.Start();
    }
}
