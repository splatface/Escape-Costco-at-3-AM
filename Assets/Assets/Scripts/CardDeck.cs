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

    private GameObject[] cards = new GameObject[8];

    private int _layerNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cards[0] = Card1;
        cards[1] = Card2;
        cards[2] = Card3;
        cards[3] = Card4;
        cards[4] = Card5;
        cards[5] = Card6;
        cards[6] = Card7;
        cards[7] = Card8;
        InstantiateAll(this._layerNumber);
        //foreach (GameObject card in cards)
        //{
        //    Card cardobject = card.GetComponent<Card>();
        //    Debug.Log(cardobject.GetNumber());
        //}
        Shuffle();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateAll(int layer)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject newCard = Instantiate(cards[i], new Vector3(-7f + i*2, 0f, 1f), transform.rotation);
            Renderer objectRenderer = newCard.GetComponent<Renderer>(); 
            if (objectRenderer != null)
            {
                objectRenderer.sortingOrder = layer;
            }
        }
    }
    public void RemoveAll()
    {
        // THIS DOESNT WORK !!! 
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetActive(false);
        }
    }
    public void Shuffle()
    {
        // sorting by numbers first, then by suits (alphabetical) within the numbers 
        for (int j = 0; j < cards.Length - 1; j++)
        {
            Card card1 = cards[j].GetComponent<Card>();
            Card card2 = cards[j+1].GetComponent<Card>();
            // sorting by number here 
            if (card1.GetNumber() > card2.GetNumber())
            {
                GameObject toSwap = cards[j];
                cards[j] = cards[j+1];
                cards[j+1] = toSwap; 
            }
            // sorting by suit here 
            else if (card1.GetNumber() == card2.GetNumber())
            {
                // letters: c, d, h, s 
                if (card2.GetSuit() == "club")
                {
                    GameObject toSwap = cards[j];
                    cards[j] = cards[j + 1];
                    cards[j + 1] = toSwap;
                }
                else if (card2.GetSuit() == "diamond")
                {
                    if (card1.GetSuit() != "club")
                    {
                        GameObject toSwap = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = toSwap;
                    }
                }
                else if (card2.GetSuit() == "heart")
                {
                    if (card1.GetSuit() == "spade")
                    {
                        GameObject toSwap = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = toSwap;
                    }
                }
            }
        }
        this._layerNumber += 1;
        InstantiateAll(this._layerNumber);
    }

}
