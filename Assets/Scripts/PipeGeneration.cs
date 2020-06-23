using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneration : MonoBehaviour
{
    public GameObject pipe;
    public float generationRange = 7f;
    public float bottomRange = -1f;
    public float TopRange = 3f;
    public float movementSpeed = -1f;
    public float generationDelay = 4f;
    private float generationTime = 0f;
    private List<GameObject> pipes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Game.CurrentState != GameState.Dead && Game.CurrentState != GameState.Paused)
        {
            if (Game.CurrentState == GameState.Running)
            {
                generationTime -= Time.deltaTime;

                if (generationTime <= 0)
                {
                    if (pipes.Count < 5)
                    {
                        generationTime = generationDelay;
                        pipe.transform.position = new Vector2(generationRange, Random.Range(bottomRange, TopRange));
                        pipes.Add(Instantiate(pipe));
                    }
                    else
                    {
                        generationTime = generationDelay;
                        pipes[0].transform.position = new Vector2(generationRange, Random.Range(bottomRange, TopRange));
                        pipes.Add(pipes[0]);
                        pipes.RemoveAt(0);
                    }
                }

                pipes.ForEach(p =>
                {
                    p.transform.position = new Vector2(p.transform.position.x + movementSpeed * Time.deltaTime, p.transform.position.y);
                });
            }
        }
    }
}
