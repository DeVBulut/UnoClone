    public enum CardColor { Red, Yellow, Green, Blue, Black }
    public enum CardType { Number, Skip, Reverse, Draw2, Draw4, ChangeColor }

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
