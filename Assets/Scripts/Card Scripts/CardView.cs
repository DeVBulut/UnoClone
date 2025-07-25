using System;
using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{

    [SerializeField] private TMP_Text numberText;
    [SerializeField] private MeshRenderer cardMeshRenderer;
    public GameManager gameManager;

    void Awake()
    {
        ComponentCheck();   
        // Ensure Collider is present
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
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
        (cardMeshRenderer == null)
        {
            Debug.LogWarning("Component not assigned -> spriteRenderer");
        }

        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    public void Setup(CardData data)
    {
        if (data.value != null) numberText.text = data.value.ToString();
        else numberText.text = data.cardType.ToString();
        cardMeshRenderer.material.SetColor("_BaseColor", GetColor(data.cardColor));
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

    public void DisableInteraction()
    {
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (gameManager != null)
        {
            gameManager.PlayCard(this);
        }
    }
}
