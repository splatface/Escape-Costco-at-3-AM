using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private static List<PowerUpEffect> _powerupList;
    private static List<GameObject> _powerupObjects;

    private static List<PowerUpEffect> _powerupSearchList;
    private static List<GameObject> _powerupSearchObjects;


    private static List<Vector2> _powerupPositions = new List<Vector2>
    {
        new Vector2(-496f, 35f),
        new Vector2(-248f, 35f),
        new Vector2(0f, 35f),
        new Vector2(248f, 35f),
        new Vector2(496f, 35f)
    };

    public void Awake()
    {
        _powerupList = new List<PowerUpEffect>(GetComponentsInChildren<PowerUpEffect>());

        _powerupObjects = new List<GameObject>();
        foreach (PowerUpEffect p in _powerupList)
            _powerupObjects.Add(p.gameObject);
    }

    public static void SortTimePlusPower()
    {
        for (int i = 0; i < (_powerupList.Count - 1); i++)
        {
            int minIndex = i;
            for (int j = i+1; j < _powerupList.Count; j++)
            {
                if ((_powerupList[j].GetBuff() + _powerupList[j].GetDuration()) < (_powerupList[minIndex].GetBuff() + _powerupList[minIndex].GetDuration()))
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                PowerUpEffect min = _powerupList[minIndex];
                
                _powerupList[minIndex] = _powerupList[i];
                _powerupList[i] = min;
            }
        }

        AddObjectsInOrder();
    }

        public static void SortPricePlusAlpha()
    {
        for (int i = 0; i < (_powerupList.Count - 1); i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < _powerupList.Count; j++)
            {
                if (_powerupList[j].GetPrice() < _powerupList[minIndex].GetPrice())
                {
                    minIndex = j;
                }
                else if (_powerupList[j].GetPrice() == _powerupList[minIndex].GetPrice())
                {
                    if (string.Compare(
                            _powerupList[j].GetName(),
                            _powerupList[minIndex].GetName()
                        ) < 0)
                    {
                        minIndex = j;
                    }
                }
            }

            if (minIndex != i)
            {
                PowerUpEffect min = _powerupList[minIndex];

                _powerupList[minIndex] = _powerupList[i];
                _powerupList[i] = min;
            }
        }

        AddObjectsInOrder();
    }
    public static void AddObjectsInOrder()
    {
        _powerupObjects = new List<GameObject>();
        foreach (PowerUpEffect p in _powerupList)
        {
            _powerupObjects.Add(p.gameObject);
        }
    }
    
    public static void ChangePositions()
    {
        for (int i = 0; i < _powerupObjects.Count; i++)
        {
            RectTransform rt = _powerupObjects[i].GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.anchoredPosition = _powerupPositions[i];

            }
        }
    }

    public static void ResetAllVisible()
    {
        foreach (GameObject obj in _powerupObjects)
            obj.SetActive(true);
    }

    public static int BinarySearchTimePlusPower(int target)
    {
        SortTimePlusPower();
        _powerupSearchList = new List<PowerUpEffect>(_powerupList);
        
        int low = 0;
        int high = _powerupList.Count - 1;
        int result = -1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (_powerupList[mid].GetBuff() + _powerupList[mid].GetDuration() >= target)
            {
                result = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return result;
    }

    public static void FilterTimePlusPower(string op, int value)
    {
        ResetAllVisible();
        
        foreach (PowerUpEffect p in _powerupList)
        {
            int total = p.GetBuff() + p.GetDuration();

            bool hide = false;

            if (op == "<" && total >= value)
                hide = true;
            else if (op == ">" && total <= value)
                hide = true;
            else if (op == "=" && total != value)
                hide = true;

            if (hide)
                p.gameObject.SetActive(false);
        }
    }
    public static int BinarySearchPricePlusAlpha(int targetPrice)
    {
    SortPricePlusAlpha();
    _powerupSearchList = new List<PowerUpEffect>(_powerupList);

    int low = 0;
    int high = _powerupList.Count - 1;
    int result = -1;

    while (low <= high)
    {
        int mid = (low + high) / 2;

        if (_powerupList[mid].GetPrice() >= targetPrice)
        {
            result = mid;
            high = mid - 1; 
        }
        else
        {
            low = mid + 1; 
        }
    }

    return result; 
    }
    public static void FilterPricePlusAlpha(string op, string value)
    {
    ResetAllVisible();

    if (op == ">" || op == "<" || op == "=")
        {
        int priceValue;
        if (!int.TryParse(value, out priceValue)) return;

        foreach (PowerUpEffect p in _powerupList)
            {
            int price = p.GetPrice();
            bool hide = false;

            if (op == ">" && price <= priceValue)
                hide = true;
            else if (op == "<" && price >= priceValue)
                hide = true;
            else if (op == "=" && price != priceValue)
                hide = true;

            if (hide)
                p.gameObject.SetActive(false);
            }
        }
    else
        {
        string search = value.ToLower();
        foreach (PowerUpEffect p in _powerupList)
            {
            if (!p.GetName().ToLower().Contains(search))
                p.gameObject.SetActive(false);
            }
        }
    }
}
