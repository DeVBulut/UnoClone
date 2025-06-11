using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Test Cards - Hardcoded
    public GameObject testDrawnCardObject;
    public CardView cardView;  
    CardData redDraw2 = new CardData(CardColor.Red, CardType.Draw2, 2, new CardEffectDraw2());
    CardData blueNumber5 = new CardData(CardColor.Blue, CardType.Number, 5, new CardEffectDefault());

    void Start()
    {
        CardData redDraw2 = new CardData(CardColor.Red, CardType.Draw2, 2, new CardEffectDraw2());
        cardView.Setup(redDraw2);
        //test drawn card object
        //GameObject testObject = new GameObject(); 
        //cardview.Setup(redDraw2, testObject);
    }



}
