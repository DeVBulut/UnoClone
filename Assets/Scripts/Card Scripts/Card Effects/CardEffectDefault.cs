using UnityEngine;

public class CardEffectDefault : ICardEffect
{
    public void Apply(GameState game, Player actor, Player target)
    {
        Debug.Log(actor.gameObject.name + " played default card");
    }
}
