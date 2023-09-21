using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] ElectricScooter Scooter;
    float alpha = 0;
    public bool FadingEvent;
    public float FadingTimer;

    public void Fade()
    {
        if (FadingEvent == true) FadeIn(alpha);
        else if (FadingEvent == false) FadeOut(alpha);

        Color color = _material.color;
        color.a = alpha;
        _material.color = color;
    }

    // Increase A value to turn into black
    public void FadeIn(float degree)
    {
        if (alpha <= 1)
        {
            degree += .005f;
            alpha = degree;
        }
    }

    // Decrease A value to turn into transparency
    public void FadeOut(float degree)
    {
        if (alpha >= 0)
        {
            degree -= .005f;
            alpha = degree;
        }
    }
}
