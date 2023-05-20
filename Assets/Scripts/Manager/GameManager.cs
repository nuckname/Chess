using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<GameState> OnGameStateChanged;

    public GameState State;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.SpawnPieces);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.SpawnPieces:
                SpawnPieces_();
                break;
            case GameState.BlacksTurn:
                break;
            case GameState.WhitesTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
        //for null errors.
        OnGameStateChanged?.Invoke(newState);
    }

    private void SpawnPieces_()
    {

    }

    public enum GameState
    {
        SpawnPieces,
        BlacksTurn,
        WhitesTurn,
        Victory,
        Lose
    }
}
