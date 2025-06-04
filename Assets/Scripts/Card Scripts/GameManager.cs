using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Test Cards - Hardcoded
    CardData redDraw2 = new CardData(CardColor.Red, CardType.Draw2, 2, new CardEffectDraw2());
    CardData blueNumber5 = new CardData(CardColor.Blue, CardType.Number, 5, new CardEffectDefault());

    private CardView cardview;

    void Start()
    {
        cardview = GetComponent<CardView>();
        //test drawn card object
        //GameObject testObject = new GameObject(); 
        //cardview.Setup(redDraw2, testObject);
    }



}
