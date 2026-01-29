using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class ScoreSave : MonoBehaviour
{
    [Header("PlayerVariables")]
    [SerializeField] private IntVariable playerDataVar;
    [SerializeField] private FloatVariable timeScoreVar;

    [Header("ScoreVariables")]
    [SerializeField] private IntVariable lastScore;
    [SerializeField] private IntVariable highScore;
    [SerializeField] private IntVariable totalScore;
    [SerializeField] private FloatVariable lastTime;
    public void SaveToJSON()
    {
        ScoreData data = LoadFromJSON();
        if (playerDataVar.integer > data.levelScore)
        {
            data.highScore = playerDataVar.integer;
        }
        data.levelScore = playerDataVar.integer;
        data.totalScore += playerDataVar.integer;
        data.timeScore = timeScoreVar.fl;

        string scoreData = JsonUtility.ToJson(data, prettyPrint: true);
        string path = Path.Combine(Application.persistentDataPath, "ScoreData.json");
        File.WriteAllText(path, scoreData);
    }
    private ScoreData LoadFromJSON()
    {
        string path = Path.Combine(Application.persistentDataPath, "ScoreData.json");

        if (!File.Exists(path))
        {
            return new ScoreData();
        }

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<ScoreData>(json);
    }

    public void LoadScore()
    {
        ScoreData data = LoadFromJSON();
        lastScore.integer = data.levelScore;
        highScore.integer = data.highScore;
        totalScore.integer = data.totalScore;
        lastTime.fl = data.timeScore;
    }
}
[System.Serializable]
public class ScoreData
{
    public int totalScore;
    public int levelScore;
    public int highScore;
    public float timeScore;
}
