using UnityEngine;

public class CardEffectSkip : ICardEffect
{
    public void Apply(GameState game, Player actor, Player target)
    {
        //Add Later
        Debug.Log(actor.gameObject.name + " applied Skip to " + target.gameObject.name + "!");
    }
}
