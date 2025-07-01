using UnityEngine;

public class CardEffectDraw4 : ICardEffect
{
    public void Apply(GameState game, Player actor, Player target)
    {
        Debug.Log(actor.gameObject.name + " applied Draw 2 to " + target.gameObject.name + "!");
    }
}
