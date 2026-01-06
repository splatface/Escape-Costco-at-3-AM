using UnityEngine;

public class ItemBaseClass : MonoBehaviour
{

    private string _name = "";
    private string _description = "";

    public SpriteRenderer _renderer;

    private Vector2 _position;

    public Rigidbody2D Item;

    public void MoveItem(float newX, float newY)
    {
        _position = new Vector2 (newX, newY);
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetName()
    {
        return _name;
    }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Item.position = _position;
    }
}
