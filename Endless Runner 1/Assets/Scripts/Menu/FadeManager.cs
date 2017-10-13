/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    public static FadeManager Instance { set; get; }

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;
    private bool _PlayerDead = false;


    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
        Debug.Log("Fade");
    }

    private void Update()
    {
        _PlayerDead = PlayerHealth.PlayerDead;
        if (_PlayerDead)
        {
            Fade(false, 1f);
        }
        else
        {
            Fade(true, .1f);
        }


        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);

        if (transition > 1 || transition < 0)
            isInTransition = false;
    }
}
*/