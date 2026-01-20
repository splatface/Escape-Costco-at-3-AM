using TMPro;
using UnityEngine;

public class ShopSearchBars : MonoBehaviour
{
    public TMP_InputField searchInput;
    [SerializeField] private ShopManager _shopManager;

    private void Start()
    {
        searchInput.onValueChanged.AddListener(OnSearchChanged);
    }

    private void OnSearchChanged(string text)
    {
        text = text.Trim();

        if (string.IsNullOrEmpty(text))
        {
            _shopManager.ResetAllVisible(); //Every time the text changes, the search should reset for the new number.
            return;
        }

        if (int.TryParse(text, out int number))
        {
            _shopManager.SearchTimePlusPower(number); //Uses the number as a target to search.
        }
    }
}
