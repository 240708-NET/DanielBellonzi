// Card User Story:
/*
    - A card should store a value
    - A card should store a suit
    - Card values 0, 11, 12, 13 should have a face
*/

class Card
{

    private char suit { get; }
    private int value { get; }
    private char? face { get; } = null;
    public Card(char suit, int value)
    {
        this.suit = suit;
        this.value = value;

        switch(value)
        {
            case 0:
                this.face = 'A';
                break;
            case 11:
                this.face = 'J';
                break;
            case 12:
                this.face = 'Q';
                break;
            case 13:
                this.face = 'K';
                break;
                
        }

    }
}