using UnityEngine;

public class BlueKeyCard : KeyCard
{
    protected override void Start()
    {
        this.Colour = "blue";
        base.Start();
    }
    protected override void Update()
    {
        OpenDoor();
    }
    public void OpenDoor()
    {
        // check if player equipped blue keycard and is touching the blue room door 
        // if so, open blue room scene 
    }
}
