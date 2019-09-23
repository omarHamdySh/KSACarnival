using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Lean.Localization;
using System;
using System.Collections.Generic;

public enum TypingTextDirection {
    rtl,
    ltr
}
public class TextTypingAnimation : MonoBehaviour
{
    public IEnumerator currentcourtine;
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterWritingSpeed = 0.01f;
    //Message that will displays till the end that will come out letter by letter
    private string ltrStrMessage;
    private string rtlStrMessage;

    //Text for the message to display
    public Text contentTxt;
    public Text headerTxt;
    public TypingTextDirection currentTyptingDirection;

    private LeanLocalizedText leanLocalizedTxt;
    IEnumerator TypeText()
    {
        if (currentTyptingDirection == TypingTextDirection.rtl)
        {
            string[] arr = ltrStrMessage.Split(new char[] {' '});
            
            List<string> inversedArr = new List<string>() ;
            List<string> lines = new List<string>() ;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals("\n"))
                {

                }
            }
            //Flip the text;
            rtlStrMessage = ltrStrMessage;
            
            
            //Start the animation on the right to left direction animation.
            //Split each char into a char array

            foreach (char letter in rtlStrMessage.ToCharArray())
            {
                if (contentTxt)
                {
                    contentTxt.text += letter;
                }
                //Add 1 letter each
                yield return 0;
                yield return new WaitForSeconds(letterWritingSpeed);
            }
        }
        else if (currentTyptingDirection == TypingTextDirection.ltr)
        {
            //Start the animation on the default direction left to right

            //Split each char into a char array
            foreach (char letter in ltrStrMessage.ToCharArray())
            {
                if (contentTxt)
                {
                    contentTxt.text += letter;
                }
                //Add 1 letter each
                yield return 0;
                yield return new WaitForSeconds(letterWritingSpeed);
            }
        }

        leanLocalizedTxt.enabled = true;
        contentTxt = null;
    }
    public void Play(string headerStr, string massage, LeanLocalizedText leanLocalizedTxt, TypingTextDirection currentTyptingDirection)
    {
        this.currentTyptingDirection = currentTyptingDirection;
        this.leanLocalizedTxt = leanLocalizedTxt;

        if (headerTxt) {
            headerTxt.text = "";
            headerTxt.text = headerStr;
        }
        if (contentTxt)
        {
            contentTxt.text = "";
        }
        ltrStrMessage = "";
        ltrStrMessage = massage;
        if (currentcourtine != null)
        {
            StopCoroutine(currentcourtine);
        }
        currentcourtine = TypeText();
        StartCoroutine(currentcourtine);
    }

}