// Card User Story:
/*
    - A card should store a value
    - A card should store a suit
    - Card values 0, 11, 12, 13 should have a face
*/

class Card
{

    private char suit { get; }
    public int value { get; }
    private char? face { get; } = null;

    public Card(char suit, int value)
    {
        this.suit = suit;
        this.value = value;

        switch(value)
        {
            case 1:
                this.face = 'A';
                this.value = 11;
                break;
            case 11:
                this.face = 'J';
                this.value = 10;
                break;
            case 12:
                this.face = 'Q';
                this.value = 10;
                break;
            case 13:
                this.face = 'K';
                this.value = 10;
                break;
                
        }

    }

    public string printCard() {
        return $"{(this.face != null ? this.face : this.value)}{this.suit}";
    }
}