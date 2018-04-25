using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private const float BaseScrollingSpeed = 0.001f;
    private const int BaseTextSize       = 60;

    public Canvas EditCanvas, PlayCanvas;
    public Scrollbar Scrollbar;
    public Text PlayerText;

    private bool _isEditing;

    private bool _isScrolling;
    private float _scrollingSpeed = BaseScrollingSpeed;

    private void Update()
    {
        if (_isScrolling && !_isEditing) Scrollbar.value = Mathf.Max(Scrollbar.value - _scrollingSpeed, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            _isEditing = !_isEditing;

            if (_isEditing)
            {
                EditCanvas.gameObject.SetActive(true);
                PlayCanvas.gameObject.SetActive(false);
                Screen.SetResolution(640, 480, false);
                _isScrolling = false;
                _scrollingSpeed = BaseScrollingSpeed;
                Scrollbar.value = 1;
                PlayerText.fontSize = BaseTextSize;
            }
            else
            {
                EditCanvas.gameObject.SetActive(false);
                PlayCanvas.gameObject.SetActive(true);
                Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !_isEditing) _scrollingSpeed /= 2;

        if (Input.GetKeyDown(KeyCode.RightArrow) && !_isEditing) _scrollingSpeed = Mathf.Min(_scrollingSpeed * 2,1);

        if (Input.GetKeyDown(KeyCode.DownArrow) && !_isEditing) PlayerText.fontSize++;

        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isEditing) PlayerText.fontSize--;

        if (Input.GetKeyDown(KeyCode.R) && !_isEditing) Scrollbar.value = 0;

        if (Input.GetKeyDown(KeyCode.S) && !_isEditing) _isScrolling = !_isScrolling;
    }
}
