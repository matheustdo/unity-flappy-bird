using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject[] numbers = new GameObject[10];
    public float spacing = 0.5f;
    public string value;
    private string lastValue = "";
    private List<GameObject> instantiatedNumbers = new List<GameObject>();
    public bool visible = true;
    private bool lastVisible;
    public bool best = false;

    void Start()
    {
        if (best)
        {
            value = Convert.ToString(Game.BestScore);
        }
        else
        {
            value = Convert.ToString(Game.CurrentScore);
        }
        lastVisible = !visible;
    }

    void Update()
    {
        if (Game.CurrentState != GameState.Menu)
        {
            if (best)
            {
                value = Convert.ToString(Game.BestScore);
            }
            else
            {
                value = Convert.ToString(Game.CurrentScore);
            }

            if (!value.Equals(lastValue))
            {
                instantiatedNumbers.ForEach(number =>
                {
                    Destroy(number);
                });

                instantiatedNumbers = new List<GameObject>();

                for (int i = 0; i < value.ToCharArray().Length; i++)
                {
                    float xPosition = 0;

                    if (value.ToCharArray().Length % 2 == 0)
                    {
                        if (i < value.ToCharArray().Length / 2)
                        {
                            xPosition = -value.ToCharArray().Length / 2 + i + spacing;
                        }
                        else
                        {
                            xPosition = i - value.ToCharArray().Length / 2 + spacing;
                        }
                    }
                    else
                    {
                        if (i == (value.ToCharArray().Length / 2))
                        {
                            xPosition = 0;
                        }
                        else if (i < value.ToCharArray().Length / 2)
                        {
                            xPosition = -value.ToCharArray().Length / 2 + i;
                        }
                        else
                        {
                            xPosition = i - value.ToCharArray().Length / 2;
                        }
                    }

                    GameObject number = Instantiate(numbers[value.ToCharArray()[i] - '0']);
                    number.transform.parent = transform;
                    if (visible)
                    {
                        number.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    }
                    else
                    {
                        number.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                    }
                    number.transform.localPosition = new Vector2(xPosition * spacing, 0f);
                    instantiatedNumbers.Add(number);
                }
            }

            if (lastVisible != visible)
            {
                instantiatedNumbers.ForEach(number =>
                {
                    if (visible)
                    {
                        number.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    }
                    else
                    {
                        number.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                    }
                });
            }
            lastVisible = visible;
            lastValue = value;
        }
    }
}
