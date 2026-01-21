using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBase : MonoBehaviour
{
    //properties of item
    public string Name = "";
    public string Description = "";
    public string Type = "";
    public virtual void UseItem()
    {
        
    }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
}
