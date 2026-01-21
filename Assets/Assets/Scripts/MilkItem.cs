using UnityEngine;

public class MilkItem : ItemBase
{

    public override void UseItem()
    {
        
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
      base.Name = "Milk";
        base.Description = "Slightly spoiled.";
        base.Type = "weapon";
        base.Start();  
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
