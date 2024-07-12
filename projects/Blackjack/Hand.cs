// Hand User Story
/*
    - A hand should hold cards
    - A hand should list a bust
    - A hand should print what cards in it
    - A dealers hand should conceal the first card
*/
using System.Net.NetworkInformation;

class Hand
{
    private List<Card> handList = new List<Card>();
    private bool isDealer;
    public int handValue { get; set; }

    public Hand(bool isDealer)
    {
        this.isDealer = isDealer;
        this.handValue = 0;
    }

    public bool DrawCard(Card newCard) {
        bool bust = false;
        handList.Add(newCard);
        handValue += newCard.value;
        if(handValue > 21) 
        {
            bust = AceCheck();
        }
        return bust;
    }

    public string ListHand(bool reveal)
    {
        string hand = "";

        foreach (Card c in handList)
        {
            
            hand += $"| {c.printCard()} | ";
        }

        if(isDealer && !reveal)
        {
            hand = "| XX | " + hand.Substring(7);
        }

        return hand.Trim();
    }

    public bool AceCheck() 
    {
        int aceCount = 0;
        this.handValue = 0;
        foreach ( Card c in handList )
        {
            if ( c.value == 11 ) aceCount++;
            this.handValue += c.value;
        }

        while( aceCount > 0 && this.handValue > 21 )
        {
            this.handValue -= 10;
            aceCount--;
        }

        return this.handValue > 21;
    }
}