using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Hand playerHand;
    public Transform discardPileAnchor;
    public Deck deck;
    public Transform discardAnchor;

    private List<CardData> discardPile = new();
    private CardData topCard;
    private CardView lastDiscardView;

    void Start()
    {
        // Draw 5 cards to start
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
        // Place initial top card
        PlaceInitialTopCard();
    }

    private void PlaceInitialTopCard()
    {
        topCard = deck.GenerateCard();
        discardPile.Add(topCard);
        // Optionally instantiate a CardView for the discard pile
        Debug.Log($"Initial top card: {topCard.cardColor} {topCard.cardType} {topCard.value}");
    }

    public void DrawCard()
    {
        CardData card = deck.GenerateCard();
        playerHand.AddCard(card);
    }

    public void PlayCard(CardView cardView)
    {
        CardData card = cardView.GetComponent<CardView>()?.GetCardData();
        if (card == null)
        {
            Debug.LogWarning("Tried to play a card with no CardData.");
            return;
        }
        if (IsLegalPlay(card, topCard))
        {
            // Remove from hand
            playerHand.RemoveCard(cardView);
            // Add to discard pile and set as top card
            discardPile.Add(card);
            topCard = card;
            // Apply effect (pass nulls for GameState/Player for now)
            card.cardEffect?.Apply(null, null, null);
            // Move cardView to discardAnchor
            if (lastDiscardView != null)
            {
                lastDiscardView.DisableInteraction();
                Destroy(lastDiscardView.gameObject);
            }
            cardView.transform.SetParent(discardAnchor);
            cardView.transform.position = discardAnchor.position;
            cardView.DisableInteraction();
            lastDiscardView = cardView;
            Debug.Log($"Played card: {card.cardColor} {card.cardType} {card.value}");
        }
        else
        {
            Debug.LogWarning($"Illegal play: {card.cardColor} {card.cardType} {card.value} on top of {topCard.cardColor} {topCard.cardType} {topCard.value}");
        }
    }

    private bool IsLegalPlay(CardData played, CardData top)
    {
        // Wilds always legal
        if (played.cardColor == CardColor.Black)
            return true;
        // Match color
        if (played.cardColor == top.cardColor)
            return true;
        // Match type
        if (played.cardType == top.cardType)
            return true;
        // Match value (for number cards)
        if (played.cardType == CardType.Number && top.cardType == CardType.Number && played.value == top.value)
            return true;
        return false;
    }

    private void RemoveCardFromHand(CardView cardView)
    {
        // Hand needs a RemoveCard(CardView) method; implement if missing
        var handType = playerHand.GetType();
        var removeMethod = handType.GetMethod("RemoveCard");
        if (removeMethod != null)
        {
            removeMethod.Invoke(playerHand, new object[] { cardView });
        }
        else
        {
            // fallback: destroy cardView
            Destroy(cardView.gameObject);
        }
    }
}

// Extension for CardView to get CardData (add this if not present)
public static class CardViewExtensions
{
    public static CardData GetCardData(this CardView view)
    {
        var field = typeof(CardView).GetField("cardData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field != null)
            return (CardData)field.GetValue(view);
        return null;
    }
}
