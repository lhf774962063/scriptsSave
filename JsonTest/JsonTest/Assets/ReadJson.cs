using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ReadJson : MonoBehaviour
{
    GameStatus status;
    void Start()
    {
         status = LoadJsonFromFile();

    }

    int iCount = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(iCount > 3)
            {
                iCount = -1;
            }
            iCount++;
           // int i = 
           switch(iCount)
            {
                case 0:
                    {
                        textStr = status.version;   
                        break;
                    }
                case 1:
                    {
                        textStr = status.gameName;
                        Debug.Log(status.gameName);
                        break;
                    }
                case 2:
                    {
                        textStr = status.gameName;
                        Debug.Log(status.isStereo);
                        break;
                    }
                case 3:
                    {
                        textStr = status.version;
                        Debug.Log(status.isUseHardWare);
                        break;
                    }
                case 4:
                    {
                        textStr = status.version;
                        Debug.Log(status.statusList);
                        break;
                    }
                case 5:
                    {
                        textStr = status.version;
                        Debug.Log(status.version);
                        break;
                    }
                default:
                    break;
            }

        }
    }

    string textStr = "这是一个button按钮";

    void OnGUI()
    {
        GUI.Label(new Rect(180, 120, 100, 150), textStr);

    }

    #region loadFile;
    public GameStatus LoadJsonFromFile()
    {


        BinaryFormatter bf = new BinaryFormatter();

        string str = getPath();
        //这是加上
        str = str + selfFileName;
        // str = str + '/';
        str = str + "_Data";
        //这是加上json本身自己的名字；
        str = str + "/pathJson.json";

        // Debug.Log(str);

        //if (!File.Exists(Application.dataPath + "/Resources/pathJson.json"))
        //{
        //    Debug.Log("NULL");
        //    return null;
        //}

        //StreamReader sr = new StreamReader(Application.dataPath + "/Resources/pathJson.json");


        if (!File.Exists(str))
        {
            return null;
        }
        StreamReader sr = new StreamReader(str);

        if (sr == null)
        {
            return null;
        }
        string json = sr.ReadToEnd();

        if (json.Length > 0)
        {
            return JsonUtility.FromJson<GameStatus>(json);
        }
      //  Debug.Log("asldfkjaskldfjaskldfjasdf");

        return null;
    }



    public string selfFileName = "Json";

    string getPath()
    {
        string str = this.GetType().Assembly.Location;
       // Debug.Log(str);

        int i = str.LastIndexOf(selfFileName);
        str = str.Substring(0, i);

        int lenth = str.Length;

        i = -1;
        string temp = "";
        while (++i < lenth)
        {
            if (str[i] == '\\')
            {

                temp = temp + '/';
            }
            else
            {
                temp = temp + str[i];
            }
        }
        return temp;
    }
    #endregion;
}