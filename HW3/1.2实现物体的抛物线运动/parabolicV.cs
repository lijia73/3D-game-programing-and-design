using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabolicV : MonoBehaviour
{
    public float dTime = 0f;//已经过去的时间
    public float speedx0 = 5.0f;
    public float speedy0 = 1.0f;
    public float ay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float time = dTime + Time.deltaTime;
        float dx = speedx0 * Time.deltaTime;
        float dy = (float)(speedy0 * Time.deltaTime + 0.5 * ay * (time * time - dTime * dTime));
        this.transform.position += new Vector3(dx, -dy);
        dTime = time;
    }
}
