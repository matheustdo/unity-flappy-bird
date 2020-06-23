using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 2f;
    private GameState lastState;
    private bool started = false;
    private float opacity = 1f;
    private bool isFadeIn = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    void Update()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
        if (started)
        {
            if (opacity >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Game.CurrentScore = 0;
            }
            if (isFadeIn)
            {
                opacity += speed * Time.deltaTime;
            }
            else
            {
                isFadeIn = lastState == GameState.Dead && Game.CurrentState == GameState.Menu;
            }

            lastState = Game.CurrentState;
        }
        else
        {
            opacity -= speed * Time.deltaTime;

            if (opacity <= 0)
            {
                opacity = 0;
                started = true;
            }
        }
    }
}
