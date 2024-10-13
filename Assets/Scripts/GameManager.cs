using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    void Awake()
    {
        Instance = this;
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
