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
    //파일 저장할 이름
    public string textFileName = "textPlayer.txt";
    public string jsonFileName = "jsonPlayer.json";
    //정보를 저장할 폴더
    public string folderName = "PlayerData";

    string folderPath;
    string txtPath;
    string jsonPath;

    private void Awake()
    {
        instance = this;

        //다양한 플랫폼에서 ㅅ ㅏ ㅇ ㅛ ㅇ
        Debug.Log(Application.persistentDataPath);
        //횬쟈 여플리케이션 경로
        Debug.Log(Application.dataPath);
        folderPath = Path.Combine(Application.dataPath, folderName);
        txtPath = Path.Combine(Application.dataPath, folderName, textFileName);
        jsonPath = Path.Combine(Application.dataPath, folderName, jsonFileName);
    }

    private void Start()
    {
        
    }

    #region txt 파일
    public void CreateFolder()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("폴더 생성 완료");
        }
    }


    public void SaveTxt(string content)
    {
        CreateFolder();
        File.WriteAllText(txtPath, content);

        Debug.Log("txt 파일 저장 완료");
    }

    public string LoadTxt()
    {
        if (File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("txt 파일 로드 실패");
        return null;
    }

    public void UpdateFile(string newContent)
    {
        if (File.Exists(txtPath))
        {
            File.WriteAllText(txtPath, newContent);
            Debug.Log("txt 파일 수정 완료");
        }
        else
        {
            Debug.LogWarning("txt 파일 수정 실패");
        }
    }

    public void DeleteFile()
    {
        if (File.Exists(txtPath))
        {
            File.Delete(txtPath);
            Debug.Log("txt 파일 삭제 완료");
        }
        else
        {
            Debug.LogWarning("txt 파일 삭제 실패");
        }
    }
    #endregion

#region json 파일

    public void SaveJson(PlayerData player)
    {

        string jsonString = JsonUtility.ToJson(player, true);
        File.WriteAllText(jsonPath, jsonString);
        Debug.Log("JSON 저장 완료");
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
            Debug.LogWarning("json 파일 로드 실패");
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
            Debug.Log("json 파일 저장 완료");
        }
    }

    public void DeleteJson()
    {
        if(File.Exists(jsonPath))
        {
            File.Delete(jsonPath);
            Debug.Log("json 파일 삭제 완료");
        }
    }
    #endregion

    //here

    public void SaveMazeTxt(string folderName)
    {
        CreateFolder();
        File.WriteAllText(txtPath, folderName);

        Debug.Log("Maze txt 파일 저장 완료");
    }
    public string MazeLoadTxt()
    {
        if (File.Exists(txtPath))
        {
            return File.ReadAllText(txtPath);
        }
        Debug.Log("Maze txt 파일 로드 실패");
        return null;
    }

}