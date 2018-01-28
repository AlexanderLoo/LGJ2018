using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuAnimation : MonoBehaviour
{

    public Image Logo;
    public Color LogoColorFull;
    public Color LogoColorFaded;
    private Vector2 LogoFullSize;
    private Vector2 LogoSmallSize;

    public Button PlayButton;
    public Button CreditsButton;
    public Button ExitButton;
    public Button BackButton;

    public Image Blackscreen;
    public Color BSColorOff;
    public Color BSColorOn;

    public float flickSpeed;
    public float flickWaitTime;
    public float bsSpeed;

    // Use this for initialization
    void Start()
    {
        InitValues();
        StartCoroutine(LogoFlick());
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))

    }

    private void InitValues()
    {
        LogoFullSize = new Vector2(307, 182);
        LogoSmallSize = new Vector2(231, 137);
    }

    private IEnumerator LogoFlick()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * flickSpeed;
            Logo.color = Color.Lerp(LogoColorFull, LogoColorFaded, t);
            Logo.rectTransform.sizeDelta = Vector2.Lerp(LogoFullSize, LogoSmallSize, t);
            yield return new WaitForEndOfFrame();
        }
        Logo.color = LogoColorFaded;
        Logo.rectTransform.sizeDelta = LogoSmallSize;
        float z = 0;
        while (z < 1)
        {
            z += Time.deltaTime * flickSpeed;
            Logo.color = Color.Lerp(LogoColorFaded, LogoColorFull, z);
            Logo.rectTransform.sizeDelta = Vector2.Lerp(LogoSmallSize, LogoFullSize, z);
            yield return new WaitForEndOfFrame();
        }
        Logo.color = LogoColorFull;
        Logo.rectTransform.sizeDelta = LogoFullSize;
        yield return new WaitForSeconds(flickWaitTime);
        StartCoroutine(LogoFlick());
    }

    private IEnumerator SetBlackscreen()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * bsSpeed;
            Blackscreen.color = Color.Lerp(BSColorOff, BSColorOn, t);
            yield return new WaitForEndOfFrame();
        }
        Blackscreen.color = BSColorOn;
    }

    public void ButtonPlay()
    {
        StartCoroutine(SetBlackscreen());
    }

    public void ButtonCredits()
    {

    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonBack()
    {

    }
}
