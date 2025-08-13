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
            outputText.text = "txt ���� �Ϸ�";
        }
        else
        {
            outputText.text = "txt ���� ����";
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
            outputText.text = "text ���� �ε� ����";
        }

    }

    public void OnAppendText()
    {
        if (!string.IsNullOrEmpty(textInput.text))
        {
            FileInOut.instance.UpdateFile(textInput.text);
            outputText.text = "txt ���� �Ϸ�";
        }
        else
        {
            outputText.text = "txt ���� ����";
        }
    }

    public void OnDeleteText()
    {
        FileInOut.instance.DeleteFile();
        outputText.text = "TXT ���� �Ϸ�!";
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
            outputText.text = "json ���� ����";
        }
        catch (System.Exception e)
        {
            outputText.text = "JSon ���� ����";
        }
    }


    public void OnLoadJson()
    {
        PlayerData player = FileInOut.instance.LoadJson();
        if (player != null)
        {
            outputText.text = "�̸�: " + player.Name + ", ����: " + player.Stage + ", ����: " + player.Score;
        }
        else
        {
            outputText.text = "json �ε� ����";
        }
    }

    public void OnUpdateJson()
    {
        try
        {
            FileInOut.instance.UpdateJsonField(nameInput.text, int.Parse(stageInput.text), int.Parse(scoreInput.text));
            outputText.text = "JSON ���� �Ϸ�!";
        }
        catch(System.Exception e)
        {
            outputText.text = $"JSON ���� ����: {e.Message}";
        }
    }


    //here fixed
    public void OnDeleteJson()
    {
        FileInOut.instance.DeleteJson();
        outputText.text = "JSON ���� �Ϸ�!";
    }

    public void OnMazeSaveText()
    {
        if (!string.IsNullOrEmpty(mazeInput.text))
        {
            FileInOut.instance.SaveTxt(mazeInput.text);
            outputText.text = "txt ���� �Ϸ�";
        }
        else
        {
            outputText.text = "txt ���� ����";
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
            outputText.text = "text ���� �ε� ����";
        }

    }

}
