using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Toggle selectedToggle;
    public Lock locker;

    public void OpenLevel(string id)
    {
        SceneManager.LoadScene(id);
    }
}
