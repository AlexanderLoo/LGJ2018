using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTest : MonoBehaviour
{

    public Image BackgroundImage;
    public Image AppImage;

    public float animSpeed;
    public float colorSpeed;
    public float moveSpeed;

    private Vector2 bigSize;
    // private Vector3 midSize;
    private Vector2 smallSize;

    private Vector2 initialPos;
    private Vector2 finalPos;

    private Color initialColor;
    private Color finalColor;


    // Use this for initialization
    void Start()
    {

        bigSize = new Vector2(213, 287);
        // midSize = new Vector2(.6f, .6f);
<<<<<<< HEAD
        smallSize = new Vector3(.14f, .1f, 1);
=======
        smallSize = new Vector2(30, 30);
>>>>>>> 7049d2a7f864cf3147609c5e7543b906e5a3d8bd

        // initialColor = new Color(255, 0, 0, 255);
        // finalColor = new Color(TestImage.color.r, TestImage.color.g, TestImage.color.b, 0);

        initialPos = BackgroundImage.rectTransform.anchoredPosition;
        finalPos = new Vector3(-213, BackgroundImage.rectTransform.anchoredPosition.y);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ScaleDownImage());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(ScaleUpImage());
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(MoveLeftImage());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(MoveRight());
        }
    }

    IEnumerator ScaleDownImage()
    {
        // Debug.Log("put");
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animSpeed;
            AppImage.rectTransform.localScale = Vector3.Lerp(bigSize, smallSize, t);

            yield return new WaitForEndOfFrame();
        }

        // StartCoroutine(FadeOutImage());
    }

    IEnumerator ScaleUpImage()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animSpeed;
            AppImage.rectTransform.localScale = Vector3.Lerp(smallSize, bigSize, t);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveLeftImage()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            BackgroundImage.rectTransform.anchoredPosition = Vector2.Lerp(initialPos, finalPos, t);

            yield return new WaitForEndOfFrame();


        }
    }

    IEnumerator MoveRight()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            BackgroundImage.rectTransform.anchoredPosition = Vector2.Lerp(finalPos, initialPos, t);

            yield return new WaitForEndOfFrame();


        }
    }

    // IEnumerator FadeOutImage()
    // {
    //     float t = 0;
    //     // float z = 0;
    //     while (t < 1)
    //     {
    //         t += Time.deltaTime * animSpeed;
    //         // z += 0.1f;
    //         // TestImage.color = Color.Lerp(initialColor, finalColor, t);
    //         TestImage.rectTransform.localScale = Vector3.Lerp(midSize, smallSize, t);

    //         yield return new WaitForEndOfFrame();
    //     }

    // }


}
