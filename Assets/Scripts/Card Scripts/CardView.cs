using System;
using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{

    [SerializeField] private TMP_Text numberText;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Awake()
    {
        ComponentCheck();   
    }

    void Start()
    {
        //CardData redDraw2 = CardData.CardColor.Red; 
    }

    private void ComponentCheck()
    {
        if
        (numberText == null)
        {
            Debug.LogWarning("Component not assigned -> numberText");
        }
        else if
        (spriteRenderer == null)
        {
            Debug.LogWarning("Component not assigned -> spriteRenderer");
        }
    }

    public void Setup(CardData data, GameObject testDrawnCardObject)
    {
        numberText.text = data.value.ToString();
        spriteRenderer.color = GetColor(data.cardColor);
        Debug.Log(data.cardColor);
    }

    private Color GetColor(CardColor cardColor)
    {
        string cardColorString = cardColor.ToString();
        switch (cardColorString)
        {
            case "Black":
                Debug.Log("Generated Card Color: Black.");
                return Color.black;
            case "Blue":
                Debug.Log("Generated Card Color: Blue.");
                return Color.blue;
            case "Green":
                Debug.Log("Generated Card Color: Green.");
                return Color.green;
            case "Yellow":
                Debug.Log("Generated Card Color: Yellow.");
                return Color.yellow;
            case "Red":
                Debug.Log("Generated Card Color: Red.");
                return Color.red;
            default:
                Debug.Log("Error thrown: Card Color not on index --> " + cardColorString);
                return Color.black;
        }
    }
}
