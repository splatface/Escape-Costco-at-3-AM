using UnityEngine;

public class Flash : ItemBase
{
    protected override void Start()
    {
        this.Name = "flash";
        this.Description = "Speed +8 for 10 seconds";
        this.Type = "interactable";
        base.Start();
    }
}
