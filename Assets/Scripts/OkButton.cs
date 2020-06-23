using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButton : MonoBehaviour
{
    public AudioSource swooshSound;

    void Update()
    {
        if (Game.CurrentState == GameState.Dead)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void OnMouseDown()
    {
        if (Game.CurrentState == GameState.Dead)
        {
            swooshSound.Play(0);
            Game.CurrentState = GameState.Menu;
        }
    }
}
