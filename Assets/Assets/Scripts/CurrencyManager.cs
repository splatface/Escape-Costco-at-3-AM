using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int _coins = 0;

    // REMEMBER TO ATTACH THIS SCRIPT TO THE PLAYER

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            this._coins += 1;
            Destroy(other.gameObject);
        }
    }
    public int GetCoins()
    {
        return this._coins;
    }
    public void AddCoins(int amount)
    {
        this._coins += amount;
    }
    public void SubtractCoins(int amount)
    {
        this._coins -= amount;
    }
}
