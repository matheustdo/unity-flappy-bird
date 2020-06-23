using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite startSprite;
    public AudioSource swooshSound;
    public SpriteRenderer black;

    void Update()
    {
        if (Game.CurrentState == GameState.Running)
        {
            black.color = new Color(1f, 1f, 1f, 0f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            GetComponent<SpriteRenderer>().sprite = pauseSprite;
        }
        else if (Game.CurrentState == GameState.Paused)
        {
            black.color = new Color(1f, 1f, 1f, 0.7f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            GetComponent<SpriteRenderer>().sprite = startSprite;
        }
        else
        {
            black.color = new Color(1f, 1f, 1f, 0f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            GetComponent<SpriteRenderer>().sprite = pauseSprite;
        }
    }

    void OnMouseDown()
    {
        if (Game.CurrentState == GameState.Running)
        {
            swooshSound.Play(0);
            Time.timeScale = 0;
            Game.CurrentState = GameState.Paused;
        }
        else if (Game.CurrentState == GameState.Paused)
        {
            swooshSound.Play(0);
            Time.timeScale = 1;
            Game.CurrentState = GameState.Running;
        }
    }
}
