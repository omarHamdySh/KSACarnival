using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleChoiceDisplayer : MonoBehaviour
{

    public List<SingleChoiceDisplayer> paragraphChoices;
    public GameObject paragraphTile;
    [HideInInspector]
    public Text thisChoiceTxt;
    LeanLocalizedText leanLocalizedTxt;


    public GameObject ParagraphTitle;
    public TextTypingAnimation typingAnimator;
    // Start is called before the first frame update
    void Start()
    {
        thisChoiceTxt = paragraphTile.GetComponent<Text>();
        leanLocalizedTxt = paragraphTile.GetComponent<LeanLocalizedText>();
    }


    public void enableThisChoice(SingleChoiceDisplayer singleChoice)
    {

        singleChoice.disableAllChoicesButThis();
        singleChoice.enableThis();

    }

    private void enableThis() {
        //Enable the highlight of the this choice.

        //enable the game object that holds the current choice header.
        ParagraphTitle.SetActive(true);

        //Disable the tile game object preparing for starting the typing animation
        paragraphTile.SetActive(true);


        //Before the animation is about to work disable the ability to change the language.
        // code goes here

        //Disable the lean Localized Text script before doing anything.
        leanLocalizedTxt.enabled = false;

        //Take or cut the text out of the text component and pass it to the typing text animator.
        typingAnimator.contentTxt = thisChoiceTxt;


        string temp = thisChoiceTxt.text;
        thisChoiceTxt.text = "";
        //Animate the text and display it.
        typingAnimator.Play("", temp);


        //After finishing the animation turn the the LeanLocalizedScript On back again.
        //leanLocalizedTxt.enabled = true;

        //After the animation is finished enable the ability to change the language.
        // code goes here

    }
    public void disableAllChoicesButThis() {
        //call their disableThisChoiceMethod():
        foreach (var item in paragraphChoices)
        {
            if (item!= this)
            {
                item.disableThisChoice();
            }
        }
    }
    public void disableThisChoice() {
        //disable the game object that holds the current choice header.
        ParagraphTitle.SetActive(false);

        //Disable the highlight of this choice.
        //Code goes here

        //Disable the tile game object that holds the current choice header.
        paragraphTile.SetActive(false);
    }
}
