using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTest : MonoBehaviour
{

    public Image TestImage;

    public float animSpeed;
    public float colorSpeed;
    public float moveSpeed;

    private Vector3 bigSize;
    private Vector3 midSize;
    private Vector3 smallSize;

    private Vector2 initialPos;
    private Vector2 finalPos;

    private Color initialColor;
    private Color finalColor;


    // Use this for initialization
    void Start()
    {

        bigSize = new Vector3(1, 1, 1);
        midSize = new Vector3(.6f, .6f, .6f);
        smallSize = new Vector3(.1f, .062f, .1f);

        initialColor = new Color(255, 0, 0, 255);
        finalColor = new Color(TestImage.color.r, TestImage.color.g, TestImage.color.b, 0);

        initialPos = TestImage.rectTransform.anchoredPosition;
        finalPos = new Vector3(-213, TestImage.rectTransform.anchoredPosition.y);

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
            TestImage.rectTransform.localScale = Vector3.Lerp(bigSize, smallSize, t);

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
            TestImage.rectTransform.localScale = Vector3.Lerp(smallSize, bigSize, t);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveLeftImage()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            TestImage.rectTransform.anchoredPosition = Vector2.Lerp(initialPos, finalPos, t);

            yield return new WaitForEndOfFrame();


        }
    }

    IEnumerator MoveRight()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            TestImage.rectTransform.anchoredPosition = Vector2.Lerp(finalPos, initialPos, t);

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
