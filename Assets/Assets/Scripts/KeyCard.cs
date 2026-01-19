using UnityEngine;

public class KeyCard : ItemBase
{
    public string Colour = "";

    protected override void Start()
    {
        this.Name = "keycard";
        this.Description = "Use this to open specific colour-coded locked doors";
        this.Type = "interactable";
        base.Start();
    }
}
