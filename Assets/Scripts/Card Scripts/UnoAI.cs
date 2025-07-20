using System.Collections;
using UnityEngine;

public class UnoAI : MonoBehaviour
{
    private GameManager gameManager;
    private Hand aiHand;
    public void Initialize(GameManager manager, Hand aiHandRef)
    {
        gameManager = manager;
        aiHand = aiHandRef;
    }

    public IEnumerator SwitchToAITurn()
    {
        gameManager.currentTurn = GameManager.PlayerTurn.AI;
        gameManager.isProcessingTurn = true;
        yield return new WaitForSeconds(1f);
        yield return gameManager.StartCoroutine(AITurn());
        gameManager.currentTurn = GameManager.PlayerTurn.Human;
        gameManager.isProcessingTurn = false;
    }

    private IEnumerator AITurn()
    {
        // Try to play a valid card
        CardView validCard = null;
        foreach (var cardView in aiHand.GetCardViews())
        {
            var card = cardView.GetCardData();
            if (gameManager.IsLegalPlay(card, gameManager.topCard))
            {
                validCard = cardView;
                break;
            }
        }
        if (validCard != null)
        {
            AIPlayCard(validCard);
            yield break;
        }
        // Draw one and try again
        gameManager.DrawCardToHand(aiHand);
        yield return new WaitForSeconds(0.5f);
        foreach (var cardView in aiHand.GetCardViews())
        {
            var card = cardView.GetCardData();
            if (gameManager.IsLegalPlay(card, gameManager.topCard))
            {
                AIPlayCard(cardView);
                yield break;
            }
        }
        // No valid play, end turn
    }

    private void AIPlayCard(CardView cardView)
    {
        CardData card = cardView.GetComponent<CardView>()?.GetCardData();
        aiHand.RemoveCard(cardView);
        gameManager.discardPile.Add(card);
        gameManager.topCard = card;
        card.cardEffect?.Apply(null, null, null);
        if (gameManager.lastDiscardView != null)
        {
            gameManager.lastDiscardView.DisableInteraction();
            Destroy(gameManager.lastDiscardView.gameObject);
        }
        cardView.transform.SetParent(gameManager.discardAnchor);
        cardView.transform.position = gameManager.discardAnchor.position;
        cardView.DisableInteraction();
        gameManager.lastDiscardView = cardView;
        Debug.Log($"AI played card: {card.cardColor} {card.cardType} {card.value}");
        if (aiHand.IsEmpty())
        {
            gameManager.gameFlow.OnAIWin();
        }
    }
} 