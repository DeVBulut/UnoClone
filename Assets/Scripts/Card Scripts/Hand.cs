using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform handAnchor;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private float spacing = 1.5f;
    [SerializeField] private float spacingZ = 0.05f; // Used for stacking without Z distortion

    private List<CardView> handCards = new();

    public void AddCard(CardData cardData)
    {
        GameObject cardGO = Instantiate(cardPrefab, handAnchor);
        CardView cardView = cardGO.GetComponent<CardView>();

        if (cardView == null)
        {
            Debug.LogError("Card prefab missing CardView component.");
            return;
        }

        cardView.Setup(cardData);
        handCards.Add(cardView);
        LayoutCards();
    }

    public void RemoveCard(CardView cardView)
    {
        if (handCards.Contains(cardView))
        {
            handCards.Remove(cardView);
            Destroy(cardView.gameObject);
            LayoutCards();
        }
    }

    private void LayoutCards()
    {
        float startX = -((handCards.Count - 1) * spacing) / 2f;

        for (int i = 0; i < handCards.Count; i++)
        {
            float zOffset = -i * spacingZ;
            Vector3 localPos = new Vector3(startX + i * spacing, 0f, zOffset);  
            handCards[i].transform.localPosition = localPos;
        }
    }
}
