using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class Deck : MonoBehaviour
{
    public static Deck Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public CardData GenerateCard()
    {
        CardColor cardColor = RandomizeColor();
        CardType cardType = RandomizeType(cardColor);
        int? cardValue = RandomizeValue(cardType);
        ICardEffect cardEffect = AssignEffect(cardType);

        Debug.Log(cardColor);
        Debug.Log(cardType);
        Debug.Log(cardValue);

        return new CardData(cardColor, cardType, cardValue, cardEffect);
    }


    private List<(CardColor cardColor, int Weight)> colorWeights = new()
    {
        (CardColor.Red, 25),
        (CardColor.Blue, 25),
        (CardColor.Green, 25),
        (CardColor.Yellow, 25),
        (CardColor.Black, 8)
    };

    private CardColor RandomizeColor()
    {
        int total = 0;
        int cumulative = 0;

        for (int i = 0; i < colorWeights.Count; i++)
        {
            total += colorWeights[i].Weight;
        }

        int diceRoll = Random.Range(0, total);

        for (int i = 0; i < colorWeights.Count; i++)
        {
            cumulative += colorWeights[i].Weight;
            if (diceRoll < cumulative)
            {
                return colorWeights[i].cardColor;
            }
        }

        return CardColor.Black;
    }

    private CardType RandomizeType(CardColor cardColor)
    {
        const int reverseWeight = 2;
        const int draw2Weight = 4;
        const int skipWeight = 6;

        int diceRoll = 0;
        switch (cardColor)
        {
            case CardColor.Black:
                {
                    diceRoll = Random.Range(0, 8);

                    if (diceRoll < 4)
                    {
                        return CardType.SwitchColor;
                    }
                    else
                    {
                        return CardType.Draw4;
                    }
                }

            default:
                {
                    diceRoll = Random.Range(0, 25);
                    if (diceRoll < reverseWeight)
                    {
                        return CardType.Reverse;
                    }
                    else if (diceRoll < draw2Weight)
                    {
                        return CardType.Draw2;
                    }
                    else if (diceRoll < skipWeight)
                    {
                        return CardType.Skip;
                    }
                    else
                    {
                        return CardType.Number;
                    }
                }

        }
    }

    private int? RandomizeValue(CardType cardType)
    {
        if (cardType != CardType.Number) { return null; };
        int diceRoll = Random.Range(0, 19);
        if (diceRoll == 18)
        {
            return 0;
        }
        else
        {
            return (diceRoll / 2) + 1;
        }
    }

    private ICardEffect AssignEffect(CardType cardType)
    {
        ICardEffect cardEffect = new CardEffectDefault();

        switch (cardType)
        {
            case CardType.Number:
                cardEffect = new CardEffectDefault();
                break;

            case CardType.Skip:
                cardEffect = new CardEffectSkip();
                break;

            case CardType.Reverse:
                cardEffect = new CardEffectReverse();
                break;

            case CardType.Draw2:
                cardEffect = new CardEffectDraw2();
                break;

            case CardType.Draw4:
                cardEffect = new CardEffectDraw4();
                break;

            case CardType.SwitchColor:
                cardEffect = new CardEffectSwitchColor();
                break;
        }

        return cardEffect;
    }
}
