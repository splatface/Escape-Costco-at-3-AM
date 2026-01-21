using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using TMPro;
using System.Collections;
using System;

public class ShopManager : MonoBehaviour
{
    private List<PowerUpEffect> _powerupList;
    private List<GameObject> _powerupObjects;
    private List<PowerUpEffect> _powerupSearchList; //Will be _powerupList but filtered for the search criteria

    [SerializeField] private CurrencyManager cm;
    [SerializeField] private TMP_Text _noFundsMessage;
    private Coroutine _noFundsCoroutine;

    private List<Vector2> _powerupPositions = new List<Vector2>
    {
        new Vector2(-496f, 35f), //Locations saved for rearranging during sort
        new Vector2(-248f, 35f),
        new Vector2(0f, 35f),
        new Vector2(248f, 35f),
        new Vector2(496f, 35f)
    };

    public void Start()
    {
        _powerupList = new List<PowerUpEffect>(GetComponentsInChildren<PowerUpEffect>());
        for(int i = 0; i < _powerupList.Count; i++)
        {
            Debug.Log("Name:" + _powerupList[i].GetName());
        }


        _powerupObjects = new List<GameObject>();
        foreach (PowerUpEffect p in _powerupList)
        {
            _powerupObjects.Add(p.gameObject);
        }


        _noFundsMessage.gameObject.SetActive(false);
    }

    public void SortTimePlusPower()
    { // Selection Sort used for efficiency
        for (int i = 0; i < (_powerupList.Count - 1); i++)
        {
            int minIndex = i; //Index of lowest found value assumed to be i
            for (int j = i+1; j < _powerupList.Count; j++)
            {
                int currentBuffSum = _powerupList[j].GetBuff() + _powerupList[j].GetDuration(); //Sum for index j
                int minBuffSum = _powerupList[minIndex].GetBuff() + _powerupList[minIndex].GetDuration(); //Sum for minIndex

                if (currentBuffSum < minBuffSum) 
                {
                    minIndex = j; //If index j has a lower sum, it becomes the new minIndex
                }
            }

            if (minIndex != i) //Checks that the minIndex changed because the following code would be useless/inefficient
            {
                PowerUpEffect min = _powerupList[minIndex];
                
                _powerupList[minIndex] = _powerupList[i];
                _powerupList[i] = min; //Swaps the location of the objects at minIndex and i
            }
        }
        
        for(int i = 0; i < _powerupList.Count; i++)
        {
            Debug.Log("Name:" + _powerupList[i].GetName());
        }
    }
    private bool ComesBefore(PowerUpEffect a, PowerUpEffect b)
    {
        if (a.GetPrice() != b.GetPrice())
        return a.GetPrice() < b.GetPrice();

        int nameCompare = string.Compare( 
            a.GetName(), 
            b.GetName(), 
            System.StringComparison.OrdinalIgnoreCase 
            ); 

        return nameCompare <= 0; }
    public void SortPricePlusAlpha()
    {
        _powerupList = MergeSort(_powerupList);
        CreateObjectList();
        ChangeObjectPositions();
    }
    private List<PowerUpEffect> MergeSort(List<PowerUpEffect> list)
    {
        if (list.Count <= 1)
        return list;

        int mid = list.Count / 2;

        List<PowerUpEffect> left = MergeSort(list.GetRange(0, mid));
        List<PowerUpEffect> right = MergeSort(list.GetRange(mid, list.Count - mid));

        return Merge(left, right);
    }
    private bool AreEqual(PowerUpEffect a, PowerUpEffect b)
    {
        return a.GetPrice() == b.GetPrice() &&
        string.Equals(a.GetName(), b.GetName(), System.StringComparison.OrdinalIgnoreCase);
    }
    private List<PowerUpEffect> Merge(List<PowerUpEffect> left, List<PowerUpEffect> right)
    {
        List<PowerUpEffect> result = new List<PowerUpEffect>();
        int i = 0, j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (ComesBefore(left[i], right[j])) 
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
            result.Add(left[i++]);

        while (j < right.Count)
            result.Add(right[j++]);

        return result;
    }
    
    public void CreateObjectList()
    {
        _powerupObjects = new List<GameObject>(); //Adds sorted powerups into object list for drawing to screen
        foreach (PowerUpEffect p in _powerupList)
        {
            _powerupObjects.Add(p.gameObject);
            Debug.Log("Number");
        }
    }

    public void ChangeObjectPositions() //Uses location list to draw objects on screen in correct order
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

    public void ResetAllVisible() //Ensures all powerups are visible on screen every time user changes the search
    {
        foreach (GameObject obj in _powerupObjects)
            obj.SetActive(true);
    }

    public void SearchTimePlusPower(int target)
    {
        // Must sort list before binary search
        SortTimePlusPower();
        CreateObjectList();
        ChangeObjectPositions();

        
        int low = 0;
        int high = _powerupList.Count - 1;
        int lowBoundaryIndex = -1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int sum = _powerupList[mid].GetBuff() + _powerupList[mid].GetDuration();

            if (sum >= target)
            {
                lowBoundaryIndex = mid; //lowBoundaryIndex is going to be placed at the lowest index that is equal or above the target
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        FilterTimePlusPower(lowBoundaryIndex, target);
    }

    public void FilterTimePlusPower(int lowBoundaryIndex, int target)
    {
        ResetAllVisible();
        
        if (lowBoundaryIndex == -1) //Target is higher than all sums, so all objects should hide.
        {
            foreach (PowerUpEffect p in _powerupList)
            {
                p.gameObject.SetActive(false);
            }
            return;
        }  

        for (int i = 0; i < lowBoundaryIndex; i++) //Shows all powerups better than the lower boundary index
        {
            _powerupList[i].gameObject.SetActive(false);
        }
    }
    
    public int BinarySearchPricePlusAlpha(int targetPrice)
    {
        SortPricePlusAlpha();

        int low = 0;
        int high = _powerupList.Count - 1;
        int result = _powerupList.Count;

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
    public void FilterPricePlusAlpha(string op, string value, int startIndex = 0)
    {
        ResetAllVisible();

        if (op == ">" || op == "<" || op == "=")
        {
            if (!int.TryParse(value, out int priceValue)) return;

            for (int i = 0; i < startIndex; i++)
                _powerupList[i].gameObject.SetActive(false);

            for (int i = startIndex; i < _powerupList.Count; i++)
            {
                int price = _powerupList[i].GetPrice();
                bool hide = false;

                if (op == ">" && price <= priceValue) hide = true;
                else if (op == "<" && price >= priceValue) hide = true;
                else if (op == "=" && price != priceValue) hide = true;

                if (hide) _powerupList[i].gameObject.SetActive(false);
            }
        }
        else 
        {
            string search = value.ToLower().Trim();
            foreach (var p in _powerupList)
            {
                if (!p.GetName().ToLower().Contains(search))
                p.gameObject.SetActive(false);
            }
        }
    }
    public void Purchase()
    {
        string parentTag = transform.parent.tag; //Get proper tag
        int funds = cm.GetCoins();
        int price = transform.parent.GetComponent<PowerUpEffect>().GetPrice();

        if (funds >= price)
        {
            cm.SubtractCoins(price);
            FullInventory.Instance.PlaceIntoInven(parentTag); 
        }
        else
        {
            if (_noFundsCoroutine != null)
                StopCoroutine(_noFundsCoroutine);

            _noFundsCoroutine = StartCoroutine(ShowInsufficientFunds());
        }
    }

    private IEnumerator ShowInsufficientFunds()
    {
        _noFundsMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        _noFundsMessage.gameObject.SetActive(false);
    }
}
