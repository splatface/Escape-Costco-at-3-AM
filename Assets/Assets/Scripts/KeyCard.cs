using UnityEngine;

public class KeyCard : ItemBaseClass
{
    public string Colour = "";

    protected override void Start()
    {
        this.Name = "Keycard";
        this.Description = "Use this to open specific colour-coded locked doors";
        this.Type = "interactable";
        base.Start();
    }
}
