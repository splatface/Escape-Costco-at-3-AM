using UnityEngine;

public class VinegarItem : ItemBase
{
    protected override void Start()
    {
        this.Name = "vinegar";
        this.Description = "One of the ingredients needed to create toxic gas.";
        this.Type = "interactable";
        base.Start();
    }
}
