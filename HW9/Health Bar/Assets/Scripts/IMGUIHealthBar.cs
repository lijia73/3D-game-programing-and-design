using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGUIHealthBar : MonoBehaviour
{
    public float health = 0f;
    private Rect healthBar;
    public Rect healthUp;
    public Rect healthDown;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = new Rect(50, 50, 200, 30);
        healthUp = new Rect(75, 80, 40, 30);
        healthDown = new Rect(175, 80, 40, 30);
    }

    void OnGUI()
    {
        if (GUI.Button(healthUp, "+"))
        {
            health = health + 0.1f > 1f ? 1f : health + 0.1f;
        }
        if (GUI.Button(healthDown, "-"))
        {
            health = health - 0.1f < 0 ? 0 : health - 0.1f;
        }
        slider.value = health;
        GUI.HorizontalScrollbar(healthBar, 0f, health, 0f, 1f);
    }
}
