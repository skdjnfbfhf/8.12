using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    public InputField textInput;
    public InputField nameInput;
    public InputField stageInput;
    public InputField scoreInput;
    //here one
    public InputField mazeInput;
    public Text outputText;


    public void OnSaveText()
    {
        if (!string.IsNullOrEmpty(textInput.text))
        {
            FileInOut.instance.SaveTxt(textInput.text);
            outputText.text = "txt 저장 완료";
        }
        else
        {
            outputText.text = "txt 저장 실패";
        }
    }

    public void OnLoadText()
    {
        string result = FileInOut.instance.LoadTxt();

        if (result != null)
        {
            outputText.text = result;
        }
        else
        {
            outputText.text = "text 파일 로드 실패";
        }

    }

    public void OnAppendText()
    {
        if (!string.IsNullOrEmpty(textInput.text))
        {
            FileInOut.instance.UpdateFile(textInput.text);
            outputText.text = "txt 수정 완료";
        }
        else
        {
            outputText.text = "txt 수정 실패";
        }
    }

    public void OnDeleteText()
    {
        FileInOut.instance.DeleteFile();
        outputText.text = "TXT 삭제 완료!";
    }

    public void OnSaveJson()
    {
        try
        {

            PlayerData player = new PlayerData();
            player.Name = nameInput.text;
            player.Stage = int.Parse(stageInput.text);
            player.Score = int.Parse(stageInput.text);

            FileInOut.instance.SaveJson(player);
            outputText.text = "json 저장 성공";
        }
        catch (System.Exception e)
        {
            outputText.text = "JSon 저장 실패";
        }
    }


    public void OnLoadJson()
    {
        PlayerData player = FileInOut.instance.LoadJson();
        if (player != null)
        {
            outputText.text = "이름: " + player.Name + ", 레벨: " + player.Stage + ", 점수: " + player.Score;
        }
        else
        {
            outputText.text = "json 로드 실패";
        }
    }

    public void OnUpdateJson()
    {
        try
        {
            FileInOut.instance.UpdateJsonField(nameInput.text, int.Parse(stageInput.text), int.Parse(scoreInput.text));
            outputText.text = "JSON 수정 완료!";
        }
        catch(System.Exception e)
        {
            outputText.text = $"JSON 수정 실패: {e.Message}";
        }
    }


    //here fixed
    public void OnDeleteJson()
    {
        FileInOut.instance.DeleteJson();
        outputText.text = "JSON 삭제 완료!";
    }

    public void OnMazeSaveText()
    {
        if (!string.IsNullOrEmpty(mazeInput.text))
        {
            FileInOut.instance.SaveTxt(mazeInput.text);
            outputText.text = "txt 저장 완료";
        }
        else
        {
            outputText.text = "txt 저장 실패";
        }
    }

    public void OnMazeLoadText()
    {
        string result = FileInOut.instance.MazeLoadTxt();

        if (result != null)
        {
            outputText.text = result;
        }
        else
        {
            outputText.text = "text 파일 로드 실패";
        }

    }

}
