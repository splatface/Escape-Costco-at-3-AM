using Unity.VisualScripting;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    // public abstract void Apply(GameObject target);

    protected int _price;
    protected string _powerUpName;
    protected int _buff;
    protected int _duration;
    public int GetPrice()
    {
        return +_price;
    }
    public void SetPrice(int price)
    {
        _price = price;
    }

    public string GetName()
    {
        return _powerUpName;
    }

    public void SetName(string name)
    {
        _powerUpName = name;
    }

    public virtual int GetBuff()
    {
        return this._buff;
    }

    public virtual void SetBuff(int newBuff)
    {
        this._buff = newBuff;
    }

    public virtual int GetDuration()
    {
        return this._duration;
    }

    public virtual void SetDuration(int newDuration)
    {
        this._duration = newDuration;
    }

}
