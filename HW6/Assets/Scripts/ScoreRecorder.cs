using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder
{
    public int score;
    public void record(GameObject disk)
    {
        int s = 1;
        if (disk.GetComponent<Renderer>().material.color == new Color(255, 0, 0, 1)) s += 1;
        score+=s;
    }
    public void reset()
    {
        score = 0;
    }
}
