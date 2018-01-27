using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTest : MonoBehaviour
{

    public Image TestImage;
    public float animSpeed;
    private Vector3 bigSize;
    private Vector3 midSize;
    private Vector3 smallSize;


    // Use this for initialization
    void Start()
    {

        bigSize = new Vector3(1, 1, 1);
        midSize = new Vector3(.6f, .6f, .6f);
        smallSize = new Vector3(.1f, .1f, .1f);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("lol");
            StartCoroutine(ShrinkImage());
        }


    }

    IEnumerator ShrinkImage()
    {
        // Debug.Log("put");
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animSpeed;
            TestImage.rectTransform.localScale = Vector3.Lerp(bigSize, midSize, t);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(FadeOutImage());
    }

    IEnumerator FadeOutImage()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animSpeed;
            TestImage.rectTransform.localScale = Vector3.Lerp(midSize, smallSize, t);

            yield return new WaitForEndOfFrame();
        }

    }


}
