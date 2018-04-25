using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Canvas EditCanvas, PlayCanvas;
    public Scrollbar Scrollbar;

    private bool _isEditing;
    private bool _isScrolling;
    private float _scrollingSpeed;
    private const float baseScrollingSpeed = 0.001f;

    private void Update()
    {
        if (_isScrolling && !_isEditing) Scrollbar.value = Mathf.Min(Scrollbar.value + baseScrollingSpeed, 1);

        if (Input.GetKeyDown(KeyCode.F))
        {
            _isEditing = !_isEditing;

            if (_isEditing)
            {
                EditCanvas.gameObject.SetActive(true);
                PlayCanvas.gameObject.SetActive(false);
                Screen.SetResolution(640, 480, false);
            }
            else
            {
                EditCanvas.gameObject.SetActive(false);
                PlayCanvas.gameObject.SetActive(true);
                Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !_isEditing)
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !_isEditing)
        {

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !_isEditing)
        {

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isEditing)
        {

        }
    }
}
