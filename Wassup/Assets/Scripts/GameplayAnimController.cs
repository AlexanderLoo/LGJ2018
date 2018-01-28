using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayAnimController : MonoBehaviour
{

    public CanvasGroup PhoneBackground;
    public CanvasGroup ChatScreen;
    public Image AppGps;
    public Image AppChat;

    public float animSpeed;
    public float moveSpeed;
    public float alphaFadeSpeed;

    private Vector2 smallSize;
    private Vector2 bigSize;


    private Vector2 smallPos;
    private Vector2 bigPos;

    private Vector3 leftPos;
    private Vector3 rightPos;



    // Use this for initialization
    void Start()
    {
        InitValues();
    }

    void InitValues()
    {
        smallSize = new Vector2(0, 0);
        bigSize = new Vector2(279, 490);

        smallPos = new Vector2(0, 89);
        bigPos = new Vector2(0, 0);

        leftPos = PhoneBackground.transform.localPosition;
        rightPos = new Vector3(-279, PhoneBackground.transform.localPosition.y, PhoneBackground.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(ScaleIcon(AppGps, "Small", "Left"));
        if (Input.GetKeyDown(KeyCode.D))
            StartCoroutine(ScaleIcon(AppChat, "Small", "Right"));

    }

    private IEnumerator MoveBackground(string _direction)
    {
        float t = 0;
        if (_direction == "Left")
        {
            while (t < 1)
            {
                t += Time.deltaTime * moveSpeed;
                PhoneBackground.transform.localPosition = Vector3.Lerp(leftPos, rightPos, t);

                yield return new WaitForEndOfFrame();
            }
            StartCoroutine(ScaleIcon(AppChat, "Big", _direction));
        }
        else if (_direction == "Right")
        {
            while (t < 1)
            {
                t += Time.deltaTime * moveSpeed;
                PhoneBackground.transform.localPosition = Vector3.Lerp(rightPos, leftPos, t);

                yield return new WaitForEndOfFrame();
            }
            StartCoroutine(ScaleIcon(AppGps, "Big", _direction));
        }
    }

    private IEnumerator ScaleIcon(Image _icon, string _toSize, string _direction)
    {
        float t = 0;
        if (_toSize == "Big")
        {
            while (t < 1)
            {
                t += Time.deltaTime * animSpeed;
                _icon.rectTransform.sizeDelta = Vector2.Lerp(smallSize, bigSize, t);
                _icon.rectTransform.anchoredPosition = Vector3.Lerp(smallPos, bigPos, t);

                yield return new WaitForEndOfFrame();
            }
            _icon.rectTransform.sizeDelta = bigSize;
            _icon.rectTransform.anchoredPosition = bigPos;
            if (_icon == AppChat)
            {
                float z = 0;
                while (z < 1)
                {
                    z += Time.deltaTime * alphaFadeSpeed;
                    ChatScreen.alpha = Mathf.Lerp(0, 1, z);

                    yield return new WaitForEndOfFrame();
                }

                ChatScreen.alpha = 1;

            }
            else if (_icon == AppGps)
            {

            }
        }
        else if (_toSize == "Small")
        {
            while (t < 1)
            {
                t += Time.deltaTime * animSpeed;
                _icon.rectTransform.sizeDelta = Vector2.Lerp(bigSize, smallSize, t);
                _icon.rectTransform.anchoredPosition = Vector3.Lerp(bigPos, smallPos, t);

                yield return new WaitForEndOfFrame();
            }
            StartCoroutine(MoveBackground(_direction));
        }
    }
}
