using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
    SteamVR_TrackedObject trackdeObject;
    SteamVR_Controller.Device device;
    public GameObject controller;

    // Use this for initialization
    void Start () {
        trackdeObject = controller.GetComponent<SteamVR_TrackedObject>();

        StartCoroutine(handIE());


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator handIE()
    {
       // yield return new WaitForSeconds(5);
        //while(true)
        //{
        //    Debug.Log(gameObject.name);
        //    yield return null;
        //}
        if (trackdeObject.isValid)
        {
            trackdeObject = controller.GetComponent<SteamVR_TrackedObject>();
        }
        while (true)
        {
            if ((int)trackdeObject.index > 0)
            {
                break;
            }
            yield return null;
        }

        while (true)
        {

            device = SteamVR_Controller.Input((int)trackdeObject.index);

            //如果手柄的Trigger键被按下了

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger" + gameObject.name);
            }
            //返回键被按下；
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                string str = getPath();
                str = str + nameStr;
                Debug.Log(str + gameObject.name);
               // press2return.returnFun(str);
            }

            yield return null;
        }
        Debug.Log("break");
        yield return null;
    }

    //被调用的exe名字；
    public string nameStr;
    //本exe名字；
    public  string selfFileName = "Teach_en";

    string getPath()
    {
        string str = this.GetType().Assembly.Location;
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
}
