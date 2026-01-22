using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    private int _coins;

    public TextMeshProUGUI CoinCount;

    public static CurrencyManager Instance { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCoinCount();
    }

    void Awake()
    {
        if (Instance == null) // makes it so that only one exists at a time
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // destroy(this) would destroy the one we want
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetCoins()
    {
        return this._coins;
    }
    public void AddCoins(int amount)
    {
        this._coins += amount;
        SetCoinCount();
    }
    public void SubtractCoins(int amount)
    {
        this._coins -= amount;
        SetCoinCount();
    }
    public void SetCoinCount()
    {
        CoinCount.text = "Coins:" + this._coins.ToString();
    }
}
