using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        gameState = GameState.Flowing;
    }

    private void LateUpdate()
    {
        //for (int i = 0; i < carControllers.Length; i++)
        //{

        //}
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
