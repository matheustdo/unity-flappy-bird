using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameState CurrentState = GameState.Menu;
    public static int CurrentScore = 0;
    public static int BestScore = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestScore = PlayerPrefs.GetInt("BestScore");
        }
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("BestScore", BestScore);
        PlayerPrefs.Save();
    }
}
