using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHalo : MonoBehaviour
{
    public ParticleSystem particleSystem;// 粒子系统
    private ParticleSystem.Particle[] particleArray;// 粒子数组
    private int haloResolution = 3500;// 粒子数量
    private float minRadius = 2.5F;// 最小半径
    private float maxRadius = 4F;// 最大半径
    private HaloParticleData[] haloParticledata;//粒子数据
    private float shrinkSpeed = 0.5f;//缩放速度       
    private float[] max;// 扩张后粒子半径
    private float[] min;// 收缩后粒子半径
    private bool direction = true; //T-收缩 F-扩张
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = this.GetComponent<ParticleSystem>();
        particleArray = new ParticleSystem.Particle[haloResolution];
        haloParticledata = new HaloParticleData[haloResolution];
        max = new float[haloResolution];
        min = new float[haloResolution];

        particleSystem.Emit(haloResolution);
        particleSystem.GetParticles(particleArray);
        for (int i = 0; i < haloResolution; ++i)
        {
            float shiftMinRadius = Random.Range(1, (maxRadius + minRadius) / 2 / minRadius);
            float shiftMaxRadius = Random.Range((maxRadius + minRadius) / 2 / maxRadius, 1);
            float radius = Random.Range(minRadius * shiftMinRadius, maxRadius * shiftMaxRadius);
            max[i] =  radius+1;
            min[i] =  radius-1;
            float angle = Random.Range(0, Mathf.PI * 2);

            haloParticledata[i] = new HaloParticleData(radius, angle);
            particleArray[i].position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
        particleSystem.SetParticles(particleArray, particleArray.Length);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < haloResolution; ++i)
        {
            haloParticledata[i].angle -= Random.Range(0, 1F / 360) / 2;

            if (direction)
            {
                if (haloParticledata[i].radius > min[i]) haloParticledata[i].radius -= shrinkSpeed *  Time.deltaTime;
                else direction = false;
            }
            else
            {
                if (haloParticledata[i].radius < max[i]) haloParticledata[i].radius += shrinkSpeed *  Time.deltaTime;
                else direction = true;
            }

            float angle = haloParticledata[i].angle;
            float radius = haloParticledata[i].radius;
            particleArray[i].position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
        particleSystem.SetParticles(particleArray, particleArray.Length);
    }
}
