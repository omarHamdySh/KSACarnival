using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Lean.Localization;
using System;
using System.Collections.Generic;

public enum TypingTextDirection
{
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
            #region Deprecated
            string[] lines = ltrStrMessage.Split(
                new[] { "\r\n", "\r", "\n", Environment.NewLine },
                    StringSplitOptions.None
                    );

        for (int i = 0; i < lines.Length - 2; i++)
        {
            lines[i] += "\n";
        }
        //Flip the text;


        for (int k = 0; k < lines.Length - 1; k++)
        {

            //Start the animation on the right to left direction animation.
            //Split each char into a char array
            char[] charArr = lines[k].ToCharArray();
            //char[] charArr = ltrStrMessage.ToCharArray();
            int shiftStartIndex = contentTxt.text.Length;
            for (int i = charArr.Length - 1; i > 0; i--)
            {
                if (contentTxt)
                {
                    //Shift the old data to the new position in the array.
                    contentTxt.text.Insert(shiftStartIndex, contentTxt.text);
                    if (contentTxt.text.Length > 0)
                    {

                        //contentTxt.text.Insert(
                        //    ((shiftStartIndex - 2) - (i > 0 ? i : 0)),
                        //    charArr[i].ToString());
                    }
                    else
                    {
                        string temp = contentTxt.text;
                        contentTxt.text = charArr[i].ToString();
                        contentTxt.text += temp;
                    }
                }

                //}
                //Add 1 letter each
                yield return 0;
                yield return new WaitForSeconds(letterWritingSpeed);
            }
        }



            #endregion

            //    string[] lines = ltrStrMessage.Split(
            //        new[] { "\r\n", "\r", "\n", Environment.NewLine },
            //            StringSplitOptions.None
            //            );

            //    for (int i = 0; i < lines.Length - 2; i--)
            //    {
            //        lines[i] += "\n";
            //    }
            //    //Flip the text;


            //    for (int k = 0; k < lines.Length - 1; k++)
            //    {

            //        //Start the animation on the right to left direction animation.
            //        //Split each char into a char array
            //        char[] charArr = lines[k].ToCharArray();
            //        for (int i = charArr.Length - 1; i > 0; i--)
            //        {
            //            if (contentTxt)
            //            {
            //                string temp = contentTxt.text;
            //                contentTxt.text = charArr[i].ToString();
            //                contentTxt.text += temp;
            //            }
            //            //Add 1 letter each
            //            yield return 0;
            //            yield return new WaitForSeconds(letterWritingSpeed);
            //        }
            //    }

            //    foreach (char letter in rtlStrMessage.ToCharArray())
            //    {
            //        if (contentTxt)
            //        {
            //            contentTxt.text += letter;
            //        }
            //        //Add 1 letter each
            //        yield return 0;
            //        yield return new WaitForSeconds(letterWritingSpeed);


            //    }
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

        if (headerTxt)
        {
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