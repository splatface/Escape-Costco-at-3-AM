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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawncard1 = Instantiate(Card1, transform.position, transform.rotation);
        cards[0] = spawncard1;
        GameObject spawncard2 = Instantiate(Card2, transform.position, transform.rotation);
        cards[1] = spawncard2;
        GameObject spawncard3 = Instantiate(Card3, transform.position, transform.rotation);
        cards[2] = spawncard3;
        GameObject spawncard4 = Instantiate(Card4, transform.position, transform.rotation);
        cards[3] = spawncard4;
        GameObject spawncard5 = Instantiate(Card5, transform.position, transform.rotation);
        cards[4] = spawncard5;
        GameObject spawncard6 = Instantiate(Card6, transform.position, transform.rotation);
        cards[5] = spawncard6;
        GameObject spawncard7 = Instantiate(Card7, transform.position, transform.rotation);
        cards[6] = spawncard7;
        GameObject spawncard8 = Instantiate(Card8, transform.position, transform.rotation);
        cards[7] = spawncard8;
        Shuffle();
        foreach (GameObject card in cards)
        {
            Card cardobject = card.GetComponent<Card>();
            Debug.Log(cardobject.GetNumber());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
        // sorting by numbers first, then by suits (alphabetical) within the numbers 
        for (int j = 0; j < cards.Length - 1; j++)
        {
            Card card1 = cards[j].GetComponent<Card>();
            Card card2 = cards[j+1].GetComponent<Card>();
            if (card1.GetNumber() > card2.GetNumber())
            {
                GameObject toSwap = cards[j];
                cards[j] = cards[j+1];
                cards[j+1] = toSwap; 
            }
        }
        
    }
}
