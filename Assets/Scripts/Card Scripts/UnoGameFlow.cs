using UnityEngine;

public class UnoGameFlow : MonoBehaviour
{
    private GameManager gameManager;
    private Hand playerHand;
    private Hand aiHand;
    public void Initialize(GameManager manager, Hand player, Hand ai)
    {
        gameManager = manager;
        playerHand = player;
        aiHand = ai;
    }

    public void OnPlayerWin()
    {
        gameManager.gameOver = true;
        Debug.Log("You Win!");
        // Optionally trigger UI here
    }

    public void OnAIWin()
    {
        gameManager.gameOver = true;
        Debug.Log("AI Wins!");
        // Optionally trigger UI here
    }

    public void RestartGame()
    {
        gameManager.StopAllCoroutines();
        // Clear hands
        playerHand.ClearHand();
        aiHand.ClearHand();
        // Clear discard
        gameManager.discardPile.Clear();
        gameManager.topCard = null;
        if (gameManager.lastDiscardView != null)
        {
            Destroy(gameManager.lastDiscardView.gameObject);
            gameManager.lastDiscardView = null;
        }
        // Reset game state
        gameManager.gameOver = false;
        gameManager.currentTurn = GameManager.PlayerTurn.Human;
        gameManager.isProcessingTurn = false;
        // Redraw hands
        for (int i = 0; i < 5; i++)
        {
            gameManager.DrawCardToHand(playerHand);
            gameManager.DrawCardToHand(aiHand);
        }
        gameManager.PlaceInitialTopCard();
    }
} 