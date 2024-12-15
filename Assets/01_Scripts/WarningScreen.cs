using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScreen : MonoBehaviour
{
    [Header("FOR WARNING SCREEN")]
    [Space]
    public float timeToRead;
    public Animator blackScreenAnimator;
    public GameObject warningScreen;

    [Header("FOR PC")]
    [Space]
    public Animator pcAnimator;
    public GameObject pcClick;



    private void Start()
    {
        StartCoroutine(FadeOut());
        pcClick.SetActive(false);
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeToRead);

        blackScreenAnimator.Play("WarningFadeOut");

    }

    public void HideWarningScreen()
    {
        warningScreen.SetActive(false);
        pcAnimator.Play("PCOn");
        pcClick.SetActive(true);
    }
}
