using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLanguage : MonoBehaviour
{
    public LeanLocalization ll;

    public void toggleLanguage() {
        if (LeanLocalization.CurrentLanguage.ToLower().Equals("arabic"))
        {
            ll.SetCurrentLanguage("English");
        }
        else if (LeanLocalization.CurrentLanguage.ToLower().Equals("english")) {
            ll.SetCurrentLanguage("Arabic");

        }


    }
}
