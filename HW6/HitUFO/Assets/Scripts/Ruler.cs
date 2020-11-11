using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Ruler
{     
    public void setDiskProperty(GameObject disk, int round)
    {
        disk.transform.position = this.setRandomInitPos();
        disk.GetComponent<Renderer>().material.color = setRandomColor();
        disk.transform.localScale = setScale(round);
        disk.GetComponent<DiskData>().angle = setRandomAngle();
        disk.GetComponent<DiskData>().power = setPower(round);
    }

    public Vector3 setRandomInitPos()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-1f, 5f);
        float z = Random.Range(-3f, 3f);
        return new Vector3(x, y, z);
    }

    public Vector4 setRandomColor()
    {
        int r = Random.Range(0f, 1f) > 0.5 ? 255 : 0;
        int g = Random.Range(0f, 1f) > 0.5 ? 255 : 0;
        int b = Random.Range(0f, 1f) > 0.5 ? 255 : 0;
        return new Vector4(r, g, b, 1);
    }

    public Vector3 setScale(int round)
    {
        float x = Random.Range((float)(1 - 0.1 * round), (float)(2 - 0.1 * round));
        float y = Random.Range((float)(1 - 0.1 * round), (float)(2 - 0.1 * round));
        float z = Random.Range((float)(1 - 0.1 * round), (float)(2 - 0.1 * round));
        return new Vector3(x, y, z);
    }

    public float setRandomAngle()
    {
        return Random.Range(-360f, 360f);
    }

    public float setPower(int round)
    {
        return round;
    }

    public float setInterval(int round)
    {
        return (float)(2 - 0.2 * round);
    }

    public int getTargetThisRound(int round)
    {
        if (round != -1)
        {
            return 5 + round > 10 ? 10 : 5 + round;
        }
        return 0;
    }

    public bool enterNextRound(int round,int score)
    {
        if (round != -1 && score >= (5 + round > 10 ? 10 : 5 + round))
        {
            return true;
        }
        return false;
    }
}