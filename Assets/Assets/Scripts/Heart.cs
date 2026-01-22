using UnityEngine;

public class Health : ItemBase
{
    protected override void Start()
    {
        this.Name = "heart";
        this.Description = "Health +10";
        this.Type = "interactable";
        base.Start();
    }
}

