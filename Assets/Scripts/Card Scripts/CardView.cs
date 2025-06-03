using UnityEngine;

public class CardView : MonoBehaviour
{
    void Start()
    {
        //CardData redDraw2 = CardData.CardColor.Red; 
    }

    public void Setup(CardData data, GameObject testDrawnCardObject)
    {
        //Just a demonstration of what I want to achieve
        //testDrawnCardObject.color = data.cardColor; 
        //testDrawnCardObject.cardNumber = data.value; 
        Debug.Log(data.cardColor);
    }
}
