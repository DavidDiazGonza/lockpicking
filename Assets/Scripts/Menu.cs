using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    private void Start()
    {
        SavedData savedData = SaverManager.Load();

        for (int i = 0; i< savedData.levels.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(savedData.levels[i].levelName);
            newButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(savedData.levels[i].difficulty);
            int value = savedData.levels[i].levelName[savedData.levels[i].levelName.Length - 1] - '0';
            newButton.GetComponent<Button>().onClick.AddListener(() => OpenLevel(value));
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            List<ConnectionData> connections = new List<ConnectionData>();
            connections.Add(new ConnectionData("piece1", true));

            List<PieceData> entries = new List<PieceData>();
            entries.Add(new PieceData("piece1", 5));
            entries.Add(new PieceData("piece2", 15, connections));
            entries.Add(new PieceData("piece3", -15));
            Level level = new Level("level-1", "easy", entries);

            List<ConnectionData> connections2 = new List<ConnectionData>();
            connections2.Add(new ConnectionData("piece1", true));
            connections2.Add(new ConnectionData("piece3", true));


            List<PieceData> entries2 = new List<PieceData>();
            entries2.Add(new PieceData("piece1", 5));
            entries2.Add(new PieceData("piece2", 15, connections2));
            entries2.Add(new PieceData("piece3", -15));
            Level level2 = new Level("level-2", "hard", entries2);

            List<Level> levelList = new List<Level>();
            levelList.Add(level);
            levelList.Add(level2);

            SaverManager.Save(new SavedData(levelList));
        }*/
    }

    public void OpenLevel(int id)
    {
        GameManager.currentLevel = id;
        SceneManager.LoadScene("LockPickingScene");
    }
}
