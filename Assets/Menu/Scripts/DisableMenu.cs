using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    public GameObject menu;

    public void DisableMenuFunc()
    {
        menu.SetActive(false);
    }
}
