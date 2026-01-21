using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ItemBase : MonoBehaviour
{
    //properties of item
    public string Name = "";
    public string Description = "";
    public string Type = "";
    public Rigidbody2D ItemRigidBody;
    public virtual void UseItem()
    {
        
    }

    public virtual void MoveItem(Vector3 newPos, bool needConstantChange) // moves the item
    {
        if (needConstantChange == false)
        {
            ItemRigidBody.MovePosition(newPos);
        }
        else
        {
            ItemRigidBody.linearVelocity = newPos;
        }
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
