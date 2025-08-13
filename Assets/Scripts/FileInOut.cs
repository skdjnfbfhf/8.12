using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.Rendering;

public class PlayerData
{
    public string Name;
    public int Stage;
    public int Score;
}
public class FileInOut : MonoBehaviour
{
    public static FileInOut instance = null;
    //���� ������ �̸�
    public string textFileName = "textPlayer.txt";
    public string jsonFileName = "jsonPlayer.json";
    //������ ������ ����
    public string folderName = "PlayerData";

    string folderPath;
    string txtPath;
    string jsonPath;

    private void Awake()
    {
        instance = this;

        //�پ��� �÷������� �� �� �� �� ��
        Debug.Log(Application.persistentDataPath);
        //���� ���ø����̼� ���
        Debug.Log(Application.dataPath);
        folderPath = Path.Combine(Application.dataPath, folderName);
        txtPath = Path.Combine(Application.dataPath, folderName, textFileName);
        jsonPath = Path.Combine(Application.dataPath, folderName, jsonFileName);
    }

    private void Start()
    {
        
    }

    #region txt ����
    public void CreateFolder()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("���� ���� �Ϸ�");
        }
    }


    public void SaveTxt(string content)
    {
        CreateFolder();
        File.WriteAllText(txtPath, content);

        Debug.Log("txt ���� ���� �Ϸ�");
    }

    public string LoadTxt()
    {
        if (File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("txt ���� �ε� ����");
        return null;
    }

    public void UpdateFile(string newContent)
    {
        if (File.Exists(txtPath))
        {
            File.WriteAllText(txtPath, newContent);
            Debug.Log("txt ���� ���� �Ϸ�");
        }
        else
        {
            Debug.LogWarning("txt ���� ���� ����");
        }
    }

    public void DeleteFile()
    {
        if (File.Exists(txtPath))
        {
            File.Delete(txtPath);
            Debug.Log("txt ���� ���� �Ϸ�");
        }
        else
        {
            Debug.LogWarning("txt ���� ���� ����");
        }
    }
    #endregion

#region json ����

    public void SaveJson(PlayerData player)
    {

        string jsonString = JsonUtility.ToJson(player, true);
        File.WriteAllText(jsonPath, jsonString);
        Debug.Log("JSON ���� �Ϸ�");
    }

    public PlayerData LoadJson()
    {
        if(File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("json ���� �ε� ����");
            return null;
        }
    }

    public void UpdateJsonField(string name, int stage, int score)
    {
        PlayerData data = LoadJson();
        if(data != null)
        {
            data.Name = name;
            data.Stage = stage;
            data.Score = score;
            SaveJson(data);
            Debug.Log("json ���� ���� �Ϸ�");
        }
    }

    public void DeleteJson()
    {
        if(File.Exists(jsonPath))
        {
            File.Delete(jsonPath);
            Debug.Log("json ���� ���� �Ϸ�");
        }
    }
    #endregion

    //here

    public void SaveMazeTxt(string folderName)
    {
        CreateFolder();
        File.WriteAllText(txtPath, folderName);

        Debug.Log("Maze txt ���� ���� �Ϸ�");
    }
    public string MazeLoadTxt()
    {
        if (File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("Maze txt ���� �ε� ����");
        return null;
    }

}