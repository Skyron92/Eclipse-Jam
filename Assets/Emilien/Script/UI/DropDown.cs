using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

   namespace Script
{
    public class DropDown : MonoBehaviour
    {
        public Resolution[] resolutions;
        public TMP_Dropdown dropdownMenu;

        void Awake()
        {
            resolutions = Screen.resolutions;
            dropdownMenu.options = new List<TMP_Dropdown.OptionData>();
            dropdownMenu.onValueChanged.AddListener(delegate
            {
                Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height,
                    false);
            });

            for (int i = 0; i < resolutions.Length; i++)
            {
                dropdownMenu.options.Add(new TMP_Dropdown.OptionData(ResToString(resolutions[i])));
                dropdownMenu.options[i].text = ResToString(resolutions[i]);
                dropdownMenu.value = i;
            }
        }

        string ResToString(Resolution res)
        {
            return res.width + " x " + res.height;
        }

        

    }

}