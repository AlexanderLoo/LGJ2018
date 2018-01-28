using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayAnimController : MonoBehaviour
{

    public CanvasGroup PhoneBackground;
    public Image AppGps;
    public Image AppChat;

    public float animSpeed;
    public float moveSpeed;

    private Vector2 bigSize;
    private Vector2 smallSize;

    private Vector3 leftPos;
    private Vector3 rightPos;



    // Use this for initialization
    void Start()
    {
        InitValues();
    }

    void InitValues()
    {
        leftPos = PhoneBackground.transform.localPosition;
        rightPos = new Vector3(-279, PhoneBackground.transform.localPosition.y, PhoneBackground.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(MoveBackground("Left"));
        if (Input.GetKeyDown(KeyCode.D))
            StartCoroutine(MoveBackground("Right"));

    }

    private IEnumerator MoveBackground(string direction)
    {
        float t = 0;
        if (direction == "Left")
        {
            while (t < 1)
            {
                t += Time.deltaTime * moveSpeed;
                PhoneBackground.transform.localPosition = Vector3.Lerp(leftPos, rightPos, t);

                yield return new WaitForEndOfFrame();
            }
        }
        else if (direction == "Right")
        {
            while (t < 1)
            {
                t += Time.deltaTime * moveSpeed;
                PhoneBackground.transform.localPosition = Vector3.Lerp(rightPos, leftPos, t);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
