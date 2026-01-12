using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int _number;
    [SerializeField] private string _suit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetNumber()
    {
        return this._number;
    }
    public string GetSuit()
    {
        return this._suit;
    }
}
