    public enum CardColor { Red, Yellow, Green, Blue, Black }
    public enum CardType { Number, Skip, Reverse, Draw2, Draw4, SwitchColor }

public class CardData
{


    public int? value;
    public ICardEffect cardEffect;
    public CardColor cardColor;
    public CardType cardType;

    public CardData(CardColor _cardColor, CardType _cardType, int? _value, ICardEffect _cardEffect)
    {
        this.cardColor = _cardColor;
        this.cardType = _cardType;
        this.value = _value;
        this.cardEffect = _cardEffect;
    }
}

    /* 

    A standard Uno deck contains 108 cards. 
    This includes 25 cards of each color (red, blue, green, and yellow), 
    with 19 number cards (one zero and two each of one through nine), 
    two of each action card ("Skip", "Draw Two", and "Reverse"), 
    four "Wild" cards, and four "Wild Draw Four" cards 
    
    */
