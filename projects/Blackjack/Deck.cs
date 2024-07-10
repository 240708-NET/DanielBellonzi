// Deck user story:
/*
    - A deck should be populated with 52 cards (4 suits, 13 values)
    - A deck should be able to be shuffled
    - A deck should be able to be drawn from
    - A deck should keep order and remaining cards.

    Stretch goals:
    - A deck could include multiple decks for longer play
*/

class Deck
{
    private List<Card> deckList = new List<Card>();
    private char[] suits = ['♤', '♡', '♢', '♧'];

    //Initalize Random for Shuffle
        Random rand = new Random();

    public Deck()
    {
        
        // Build Deck
        foreach (char i in suits)
        {
            for ( int j = 0; j < 14; j++ )
            {
                deckList.Add(new Card(i,j));
            } 
        }
    }

    public void ShuffleDeck() {

        // Fisher - Yates Shuffle
        for ( int i = deckList.Count; i > 0; i-- )
        {
            int sIndex = rand.Next(i);
            if(sIndex != i)
            {
                Card temp = deckList.ElementAt(sIndex);
                deckList.Insert(sIndex, deckList.ElementAt(i));
                deckList.Insert(i, temp);
            }
        }
    }

    public Card? DrawCard() {
        if(deckList.Count == 0) return null;

        Card drawnCard = deckList.ElementAt(0);
        deckList.RemoveAt(0);
        return drawnCard;
    }
}