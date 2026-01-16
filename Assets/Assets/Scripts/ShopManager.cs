using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class ShopManager : MonoBehaviour
{
    private static List<PowerUpEffect> _powerupList;
    private static List<GameObject> _powerupObjects;
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

        ChangePositions();
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
}
