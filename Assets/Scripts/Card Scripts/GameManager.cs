using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Test Cards - Hardcoded
    CardData redDraw2 = new CardData(CardData.CardColor.Red, CardData.CardType.Draw2, 2, new CardEffectDraw2());
    CardData blueNumber5 = new CardData(CardData.CardColor.Blue, CardData.CardType.Number, 5, new CardEffectDefault());

    private CardView cardview; 

    void Start()
    {
        //test drawn card object
        GameObject testObject = new GameObject(); 

        cardview.Setup(redDraw2, testObject);
    }



}
