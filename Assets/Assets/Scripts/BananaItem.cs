using UnityEngine;

public class BananaItem : ItemBaseClass
{

    public override void UseItem()
    {
        
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Name = "Banana";
        base.Description = "Bruised.";
        base.Type = "interactable";
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
