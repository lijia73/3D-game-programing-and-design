using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSun : MonoBehaviour{

    public Transform Sun, Mercury, Venus, Earth, Moon, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto;
    Vector3 axisMercury, axisVenus, axisEarth, axisMoon, axisMars, axisJupiter, axisSaturn, axisUranus, axisNeptune, axisPluto;

    // Use this for initialization
    void Start()
    {
        Sun.position = Vector3.zero;
        Mercury.position = new Vector3(8, 0, 0);
        Venus.position = new Vector3(10, 0, 0);
        Earth.position = new Vector3(15, 0, 0);
        Moon.position = new Vector3((float)(17.05), 0, 0);
        Mars.position = new Vector3(24, 0, 0);
        Jupiter.position = new Vector3(34, 0, 0);
        Saturn.position = new Vector3(44, 0, 0);
        Uranus.position = new Vector3(51, 0, 0);
        Neptune.position = new Vector3(55, 0, 0);
        Pluto.position = new Vector3(58, 0, 0);
        axisMercury = new Vector3(3, 11, 0);
        axisVenus = new Vector3(2, 3, 0);
        axisEarth = new Vector3(0, 1, 0);
        axisMoon = Vector3.up;
        axisMars = new Vector3(1, 5, 0);
        axisJupiter = new Vector3(1, 5, 0);
        axisSaturn = new Vector3(1, 9, 0);
        axisUranus = new Vector3(2, 7, 0);
        axisNeptune = new Vector3(1, 5, 0);
        axisPluto = new Vector3(1, 3, 0);
    }


    // Update is called once per frame
    void Update()
    {
        Mercury.RotateAround(Sun.position, axisMercury, 10 * Time.deltaTime);
        Venus.RotateAround(Sun.position, axisVenus, 30 * Time.deltaTime);
        Earth.RotateAround(Sun.position, axisEarth, 20 * Time.deltaTime);
        Moon.RotateAround(Earth.position, Vector3.up, 359 * Time.deltaTime);
        Mars.RotateAround(Sun.position, axisMars, 60 * Time.deltaTime);
        Jupiter.RotateAround(Sun.position, axisJupiter, 5 * Time.deltaTime);
        Saturn.RotateAround(Sun.position, axisSaturn, 6 * Time.deltaTime);
        Uranus.RotateAround(Sun.position, axisUranus, 35 * Time.deltaTime);
        Neptune.RotateAround(Sun.position, axisNeptune, 10 * Time.deltaTime);
        Pluto.RotateAround(Sun.position, axisPluto, 20 * Time.deltaTime);

        Mercury.Rotate(Vector3.up * 600 * Time.deltaTime);
        Venus.Rotate(Vector3.up * 400 * Time.deltaTime);
        Earth.Rotate(Vector3.up * 360 * Time.deltaTime);                     //自转
        Moon.Rotate(Vector3.up * 1000 * Time.deltaTime);
        Mars.Rotate(Vector3.up * 300 * Time.deltaTime);
        Jupiter.Rotate(Vector3.up * 300 * Time.deltaTime);
        Saturn.Rotate(Vector3.up * 200 * Time.deltaTime);
        Uranus.Rotate(Vector3.up * 400 * Time.deltaTime);
        Neptune.Rotate(Vector3.up * 500 * Time.deltaTime);
        Pluto.Rotate(Vector3.up * 400 * Time.deltaTime);
    }
}