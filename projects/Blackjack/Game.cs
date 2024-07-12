// Blackjack user Story
/*
    - Game starts by dealing player hands and dealer hand (2 cards each)
    - Display hands after each action
    - Offer player actions
    - Track when players or dealer bust
    - 

    Stretch:
    - Multiple players
        - ask for number of players
        - display hands and draw for each
    - continue same deck or reshuffle
    - split hands

*/

class Game{

    Deck gameDeck;

    Hand dealerHand = new Hand(true);
    Hand playerHand = new Hand(false);

    public Game() {
        gameDeck = new Deck();
    }

    public void PlayGame() {

        dealerHand = new Hand(true);
        playerHand = new Hand(false);

        dealerHand.DrawCard(gameDeck.DrawCard());
        dealerHand.DrawCard(gameDeck.DrawCard());
        playerHand.DrawCard(gameDeck.DrawCard());
        playerHand.DrawCard(gameDeck.DrawCard());

        Console.WriteLine("Welcome to Blackjack");

        bool hold = false;
        bool bust = false;
        string action;

        do
        {
            Console.WriteLine($"Dealer hand: {dealerHand.ListHand(false)}");
            Console.WriteLine($"Player hand: {playerHand.ListHand(false)} Value: {playerHand.handValue}");

            Console.WriteLine("Would you like to Draw(d) or Hold(h)?");
            action = Console.ReadLine().ToLower();

            if( action[0] == 'h' ) hold = true;
            else if( action[0] == 'd') bust = playerHand.DrawCard(gameDeck.DrawCard());

        } while ( !hold && !bust );

        while( dealerHand.handValue < 17 && !bust ) 
        {
            dealerHand.DrawCard(gameDeck.DrawCard());
        }

        if(bust) Console.WriteLine("Player Busts, Dealer Wins");
        else if(dealerHand.handValue > 21) Console.WriteLine("Dealer Busts, Player Wins");
        else if(dealerHand.handValue == playerHand.handValue) Console.WriteLine("Draw");
        else if(dealerHand.handValue > playerHand.handValue) Console.WriteLine("Dealer Wins");
        else Console.WriteLine("Player Wins");
        Console.WriteLine($"Dealer hand: {dealerHand.ListHand(true)} Value: {dealerHand.handValue}");
        Console.WriteLine($"Player hand: {playerHand.ListHand(false)} Value: {playerHand.handValue}");
    }

}