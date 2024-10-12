using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public GameState gameState;

    void Awake()
    {
        gameManagerInstance = this;
        gameState = GameState.Flowing;
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
    }


    public enum GameState
    { 
        Flowing,
        ColorMatch,
        PlayerTurn
    }

}
