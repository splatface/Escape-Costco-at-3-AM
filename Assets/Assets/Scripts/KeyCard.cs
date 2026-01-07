using UnityEngine;

public class KeyCard : ItemBaseClass
{
    public string Colour = "";
    public KeyCard()
    {
        this.Name = "keycard";
        this.Description = "Use this to open specific colour-coded locked doors";
        this.Type = "interactable";
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
