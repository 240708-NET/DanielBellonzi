// Blackjack user Story
/*
    - Game starts by dealing player hands and dealer hand (2 cards each)
    - Display hands after each action
    - Offer player actions
    - Track when players or dealer bust

    Stretch:
    - Multiple players
        - ask for number of players
        - display hands and draw for each
    - continue same deck or reshuffle

*/

using System.Net.Http.Headers;

class Game{

    Deck gameDeck;

    public Game() {
        gameDeck = new Deck();
    }
}