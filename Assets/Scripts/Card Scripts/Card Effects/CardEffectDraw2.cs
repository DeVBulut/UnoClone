using UnityEngine;

public class CardEffectDraw2 : ICardEffect
{
    public void Apply(GameState game, Player actor, Player target)
    {
        //Add Later
        Debug.Log(actor.gameObject.name + " applied Draw 2 to " + target.gameObject.name + "!");
    }
}
