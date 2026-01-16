using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;

    public GameObject ShuffleButton;
    public GameObject CheckButton;
    public GameObject SortInstructions;
    public GameObject SuitInstructions;
    public GameObject CongratsText;
    public GameObject CollectButton;

    private GameObject[] _cards = new GameObject[8];

    private int _layerNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cards[0] = Card1;
        _cards[1] = Card2;
        _cards[2] = Card3;
        _cards[3] = Card4;
        _cards[4] = Card5;
        _cards[5] = Card6;
        _cards[6] = Card7;
        _cards[7] = Card8;
        InstantiateAll(this._layerNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateAll(int layer)
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            GameObject newCard = Instantiate(_cards[i], new Vector3(-7f + i*2, 0f, 1f), transform.rotation);
            Renderer objectRenderer = newCard.GetComponent<Renderer>(); 
            if (objectRenderer != null)
            {
                objectRenderer.sortingOrder = layer;
            }
        }
    }
    public void RemoveAll()
    {
        GameObject[] oldCards = GameObject.FindGameObjectsWithTag("PlayingCard");
        for (int i = 0; i < oldCards.Length; i++)
        {
            //cards[i].SetActive(false);
            Renderer objectRenderer = oldCards[i].GetComponent<Renderer>();
            if (objectRenderer.sortingOrder < this._layerNumber)
            {
                Destroy(oldCards[i]);
            }
        }
    }
    public void Shuffle()
    {
        // sorting by numbers first, then by suits (alphabetical) within the numbers 
        for (int j = 0; j < _cards.Length - 1; j++)
        {
            Card card1 = _cards[j].GetComponent<Card>();
            Card card2 = _cards[j+1].GetComponent<Card>();
            // sorting by number here 
            if (card1.GetNumber() > card2.GetNumber())
            {
                GameObject toSwap = _cards[j];
                _cards[j] = _cards[j+1];
                _cards[j+1] = toSwap; 
            }
            // sorting by suit here 
            else if (card1.GetNumber() == card2.GetNumber())
            {
                // letters: c, d, h, s 
                if (card2.GetSuit() == "club")
                {
                    GameObject toSwap = _cards[j];
                    _cards[j] = _cards[j + 1];
                    _cards[j + 1] = toSwap;
                }
                else if (card2.GetSuit() == "diamond")
                {
                    if (card1.GetSuit() != "club")
                    {
                        GameObject toSwap = _cards[j];
                        _cards[j] = _cards[j + 1];
                        _cards[j + 1] = toSwap;
                    }
                }
                else if (card2.GetSuit() == "heart")
                {
                    if (card1.GetSuit() == "spade")
                    {
                        GameObject toSwap = _cards[j];
                        _cards[j] = _cards[j + 1];
                        _cards[j + 1] = toSwap;
                    }
                }
            }
        }
        this._layerNumber += 1;
        InstantiateAll(this._layerNumber);
        RemoveAll();
    }
    public void CheckOrder()
    {
        GameObject[] correctList = { Card4, Card6, Card5, Card1, Card8, Card7, Card2, Card3 };
        if (_cards == correctList)
        {
            // make stuff on screen disappear (including instructions, instruction boards, and buttons)
            // display correct text and have a button to "collect bleach/vinegar" then go back to other scene 
        }
        else
        {
            // display wrong text for like 2 secs then let them continue 
        }
    }
}
