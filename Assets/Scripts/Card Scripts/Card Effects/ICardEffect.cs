using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public interface ICardEffect
{
    void Apply(GameState game, Player actor, Player target);

}
