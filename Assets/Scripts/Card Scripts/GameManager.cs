using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Test Cards - Hardcoded
    public GameObject testDrawnCardObject;
    public Hand hand;
    CardData redDraw2 = new CardData(CardColor.Red, CardType.Draw2, 2, new CardEffectDraw2());
    CardData blueNumber5 = new CardData(CardColor.Blue, CardType.Number, 5, new CardEffectDefault());

    void Start()
    {
        CardData testData = Deck.Instance.GenerateCard();
        hand.AddCard(testData);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CardData testData = Deck.Instance.GenerateCard();
            hand.AddCard(testData);
        }
    }



}
