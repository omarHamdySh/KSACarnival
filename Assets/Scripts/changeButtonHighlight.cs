using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;


public class changeButtonHighlight : MonoBehaviour
{
    private Image im;
    public Sprite orignal, highlight, clicked;
    private VRTK_InteractableObject scriptio;
    public bool image_or_Color;
    // Use this for initialization
    void Start()
    {
        im = GetComponent<Image>();
        scriptio = GetComponent<VRTK_InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!image_or_Color)
        {
            if (scriptio.enabled && !scriptio.IsUsing())
            {
                im.sprite = highlight;
            }

            else if (scriptio.IsUsing() && scriptio.enabled)
            {
                im.sprite = clicked;
            }
            else
            {
                im.sprite = orignal;
            }

        }
        
        else
        {
            if (scriptio.enabled && !scriptio.IsUsing())
            {
                im.color = Color.yellow;
            }

            else if (scriptio.IsUsing())
            {
                im.color = Color.green;
            }
            else if (!scriptio.IsUsing())
            {

                im.color = Color.white;
            }
            else if (!scriptio.enabled)
            {

                im.color = Color.white;
            }
        }
    }

}

