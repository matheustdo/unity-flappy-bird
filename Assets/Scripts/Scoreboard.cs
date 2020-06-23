using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject score;
    public ScoreDisplay bestScore;

    void Start()
    {
        bestScore.visible = false;
    }

    void Update()
    {
        if (Game.CurrentState == GameState.Dead)
        {
            bestScore.visible = true;
            score.transform.position = new Vector2(0f, 0.14f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
