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

    private Card[] cards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Card card1 = Card1.GetComponent<Card>();
        cards[0] = card1;
        Card card2 = Card2.GetComponent<Card>();
        cards[1] = card2;
        Card card3 = Card3.GetComponent<Card>();
        cards[2] = card3;
        Card card4 = Card4.GetComponent<Card>();
        cards[3] = card4;
        Card card5 = Card5.GetComponent<Card>();
        cards[4] = card5;
        Card card6 = Card6.GetComponent<Card>();
        cards[5] = card6;
        Card card7 = Card7.GetComponent<Card>();
        cards[6] = card7;
        Card card8 = Card8.GetComponent<Card>();
        cards[7] = card8;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
        // sorting by numbers first, then by suits (alphabetical) within the numbers 
        for (int i = 0; i < cards.Length; i++)
        {
            for (int j = 0; j < cards.Length - 1; j++)
            {
                if (cards[j].GetNumber() > cards[j+1].GetNumber())
                {
                    Card toSwap = cards[j];
                    cards[j] = cards[j+1];
                    cards[j+1] = toSwap; 
                }
            }
        }
    }
}
