using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Toggle selectedToggle;

    public Lock locker;
    // Start is called before the first frame update
    void Start()
    {
        //selectedToggle.onValueChanged.AddListener(delegate
        //{
        //    ToggleValueChangedOccured(selectedToggle);
        //});
    }

    void ToggleValueChangedOccured(Toggle tglValue)
    {
        locker.isVersion2 = tglValue.isOn;
        locker.lockPick.isVersion2 = tglValue.isOn;
        foreach (Piece piece in locker.pieces)
        {
            piece.isVersion2 = tglValue.isOn;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLevel(string id)
    {
        SceneManager.LoadScene(id);
    }
}
