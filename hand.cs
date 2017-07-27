using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum whichHandEnum
{
    init, 
    leftHand, 
    rightHand
}

public class hand : AddAndDeleteHighLighter
{
    SteamVR_TrackedObject trackdeObject;
    SteamVR_Controller.Device device;
    public GameObject controller;

    // Use this for initialization

    void Start () {
    //   StartCoroutine(checkOverIE());
	}

    void OnEnable()
    {
        trackdeObject = controller.GetComponent<SteamVR_TrackedObject>();

        StartCoroutine(handIE());
    }


   // public whichHandEnum whichHand;
 //   int handNum = 0;

	// Update is called once per frame
	void Update () {

 

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    myAnimation.bOpenAni = true;
        //}

    }

    public static bool bLeftFirstClick, bRightFirstClick;

    public static bool bLeftCheckNet, bRightCheckNet;

    public static bool bLeftPlayed, bRightPlayed;

    //左右手柄；
    public static bool bLeftVideo_01, bRightVideo_01;
    public static bool bLeftVideo_02, bRightVideo_02;

    public GameObject rightVideoObject, leftVideoObject;

    public static bool bLeftCloseVideo, bRightCloseVideo;
    //public static videoNameEnum publicVideo = videoNameEnum.init;

    public static bool bCheckOvering, bCheckOvering_1, bCheckOvering_2, bCheckOvering_3 = false;
    public static bool bMovingP4 = false;

    public static bool bLeftP4Left_01, bLeftP4Right_01
                       , bLeftP4Left_02, bLeftP4Right_02
                         , bLeftP4Left_03, bLeftP4Right_03;

    //    public static bool bCheckOvering = false;

    //public static bool 
    public static bool bLeftMigrate, bRightMigrate;


    IEnumerator checkOverIE()
    {
        while(true)
        {
            #region p4UI弹框的问题；

            if(bLeftP4Left_01 || bLeftP4Right_01 || bLeftP4Left_02 || bLeftP4Right_02 || bLeftP4Left_03 || bLeftP4Right_03)
            {
                if (bLeftP4Left_01 || bLeftP4Right_01)
                {
                    if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_1 == false)
                    {
                    //    Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                        bCheckOvering = true;
                        bCheckOvering_1 = true;
                        yield return null;
                        if(_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.right;
                        else if(_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.right;

                        bMovingP4 = true;
                    }
                }
                if (bLeftP4Left_02 || bLeftP4Right_02)
                {
                    if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_2 == false)
                    {
                        bCheckOvering = true;
                        bCheckOvering_2 = true;
                        yield return null;
                        if(_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.mid;
                        else if(_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.mid;

                        bMovingP4 = true;
                    }
                }

               if (bLeftP4Left_03 || bLeftP4Right_03)
                {
                      //  Debug.Log("bLeftP4Right_03");
                    if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_3 == false)
                    {
                     //   Debug.Log("bLeftP4Right_03");
                        bCheckOvering = true;
                        bCheckOvering_3 = true;
                        yield return null;
                        if(_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.left;
                        else if(_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.left;
                        bMovingP4 = true;
                    }
                }
            }
            else
            {
                if (bCheckOvering == true && bMovingP4 == false)
                {
                      // Debug.Log("bLeftP4Left_02 " + Time.time);
                    bCheckOvering = false;
                    if (true == bCheckOvering_1)
                    {
                        if (_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.right;
                        else if (_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.right;
                        bCheckOvering_1 = false;
                    }

                    if (true == bCheckOvering_2)
                    {
                        if (_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.mid;
                        else if (_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.mid;
                        bCheckOvering_2 = false;
                    }

                    if (true == bCheckOvering_3)
                    {
                        if (_fps.room == roomEnum.firstRoom)
                            p4move.publicUIposi = UIposiEnum.left;
                        else if (_fps.room == roomEnum.thirdRoom)
                            p10move.publicUIposi = UIposiEnum.left;
                        bCheckOvering_3 = false;
                    }

                    yield return new WaitForSeconds(0.1f);
                    bMovingP4 = true;



                    yield return null;


                  //  Debug.Log("bLeftP4Left_01 " + Time.time);

                    //bCheckOvering = false;
                    //bMovingP4 = true;
                }
            }

                #endregion
                yield return null;
        }
    }
    public GameObject p6_secondPlayVideo_2;

    public static bool bLeftPlay, bRightPlay;

    public GameObject pullTrigger;
    public GameObject handTrigger;

    public GameObject handSmallDisk;


    public GameObject[] backHand;

    IEnumerator highLightIE()
    {
        bool bHighLight = false;
        bool bBeforeHighLight = false;
        yield return new WaitForSeconds(1);

        if (gameObject.name == "Controller (left)")
        {
            while (true)
            {
                if (bLeftFirstClick || bLeftVideo_01 || bLeftVideo_02 || bLeftPlayed || bLeftCheckNet || bLeftCloseVideo || bLeftPlay
                    || bLeftP4Left_01 || bLeftP4Left_02 || bLeftP4Left_03 || bLeftMigrate || bReset)
                {
                    device.TriggerHapticPulse(500);

                    if (bHighLight == false)
                    {
                        //到了最后一步，如果手柄粗碰reseet，就消失可以按按钮返回的提示；
                        if (bReset && _fps.bEnd == true)
                        {
                            backHand[0].SetActive(false);
                            backHand[1].SetActive(false);

                            DeleteHightLighter(handSmallDisk);
                        }

                        AddHighLighter(handTrigger);
                        pullTrigger.SetActive(true);

                        bHighLight = true;
                        // bBeforeHighLight = true;
                    }
                }
                else if (bHighLight == true)
                {
                    //到了最后一步，如果手柄没有粗碰reseet，就提示可以按按钮返回；
                    if(_fps.bEnd == true)
                    {
                        backHand[0].SetActive(true);
                        backHand[1].SetActive(true);

                        AddHighLighter(handSmallDisk);

                    }
                    
                    DeleteHightLighter(handTrigger);
                    pullTrigger.SetActive(false);

                    bHighLight = false;
                }
                yield return null;
            }
        }
        else
        {
            while (true)
            {
                if (bRightFirstClick || bRightVideo_01 || bRightVideo_02 || bRightPlayed || bRightCheckNet || bRightCloseVideo || bRightPlay
                    || bLeftP4Right_01 || bLeftP4Right_02 || bLeftP4Right_03 || bRightMigrate || bReset)
                {
                    device.TriggerHapticPulse(500);

                    if (bHighLight == false)
                    {
                        AddHighLighter(handTrigger);
                        pullTrigger.SetActive(true);

                        bHighLight = true;
                        // bBeforeHighLight = true;
                    }
                }
                else if (bHighLight == true)
                {
                    DeleteHightLighter(handTrigger);
                    pullTrigger.SetActive(false);

                    bHighLight = false;
                }
                yield return null;
                yield return null;
            }
        }

    }



    void resetFun()
    {
        Application.LoadLevel(0);
    }

    IEnumerator handIE()
    {
        yield return new WaitForSeconds(.5f);
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
        bool bBack = false;

        StartCoroutine(highLightIE());

        while (true)
        {
          //  Debug.Log(Time.time);
            device = SteamVR_Controller.Input((int)trackdeObject.index);
            //如果手柄的Trigger键被按下了

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                if(bReset == true)
                {
                    resetFun();

                }


             // Debug.Log("Trigger" + gameObject.name);
                if (gameObject.name == "Controller (left)")
                {
                    #region p4UI弹框的问题；
                    if (bLeftP4Left_01|| bLeftP4Left_02 || bLeftP4Left_03)
                    {
                        if (bLeftP4Left_01)
                        {
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_1 == false)
                            {
                                //    Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                                bCheckOvering = true;
                                bCheckOvering_1 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.right;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.right;

                                bMovingP4 = true;
                            }
                            else if(bCheckOvering == true && bMovingP4 == false && bCheckOvering_1 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.right;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.right;

                                bCheckOvering_1 = false;
                                bMovingP4 = true;
                            }
                        }
                        if (bLeftP4Left_02)
                        {
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_2 == false)
                            {
                                bCheckOvering = true;
                                bCheckOvering_2 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.mid;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.mid;

                                bMovingP4 = true;
                            }
                            else if (bCheckOvering == true && bMovingP4 == false && bCheckOvering_2 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.mid;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.mid;

                                bCheckOvering_2 = false;
                                bMovingP4 = true;
                            }
                        }

                        if (bLeftP4Left_03)
                        {
                            //  Debug.Log("bLeftP4Right_03");
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_3 == false)
                            {
                                //   Debug.Log("bLeftP4Right_03");
                                bCheckOvering = true;
                                bCheckOvering_3 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.left;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.left;
                                bMovingP4 = true;
                            }
                            else if (bCheckOvering == true && bMovingP4 == false && bCheckOvering_3 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.left;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.left;

                                bCheckOvering_3 = false;
                                bMovingP4 = true;
                            }
                        }
                    }
                    //else
                    //{
                    //    if (bCheckOvering == true && bMovingP4 == false)
                    //    {
                    //        // Debug.Log("bLeftP4Left_02 " + Time.time);
                    //        bCheckOvering = false;
                    //        if (true == bCheckOvering_1)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.right;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.right;
                    //            bCheckOvering_1 = false;
                    //        }

                    //        if (true == bCheckOvering_2)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.mid;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.mid;
                    //            bCheckOvering_2 = false;
                    //        }

                    //        if (true == bCheckOvering_3)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.left;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.left;
                    //            bCheckOvering_3 = false;
                    //        }

                    //        yield return new WaitForSeconds(0.1f);
                    //        bMovingP4 = true;
                    //        yield return null;
                    //    }
                    //}
                    #endregion

                    //   Debug.Log(gameObject.name + "lihaifeng") ;
                    //下面处理migrate的问题；
                    if(bLeftMigrate)
                    {
                        _fps.bMigrate = true;
                    }

                    //下面处理视频暂停的问题；
                    if (bLeftPlay == true)
                    {
                       // Debug.Log("bRightPlay" + gameObject.name);
                        if (playVideo.bPause == true)
                        {
                            playVideo.bStartPause = true;
                            //     playVideo.bPause = !playVideo.bPause;
                            yield return new WaitForSeconds(0.2f);
                            playVideo.bPause = false;
                            yield return new WaitForSeconds(0.2F);
                            playVideo.bStartPause = false;

                            yield return new WaitForSeconds(0.3f);
                        }
                        else
                        {
                            playVideo.bPause = true;
                            yield return new WaitForSeconds(0.3f);
                        }
                    }

                    #region OK
                    if (bLeftFirstClick == true)
                    {
                        _fps.bFinished = true;
                        //
                     //   Debug.Log("click: " + gameObject.name);
                        yield return new WaitForSeconds(2);
                    }

                    if (bLeftCheckNet == true)
                    {
                        _fps.bCheckNet = true;
                        //
                      //  Debug.Log("bLeftCheckNet: " + gameObject.name);
                        yield return new WaitForSeconds(2);
                    }
 

                    if (bLeftVideo_01 && playVideo.publicVideo == videoNameEnum.init)
                    {
                        p6_secondPlayVideo_2.SetActive(false);
                        yield return null;
                        //  leftVideoObject.SetActive(true);
                        yield return null;
                        playVideo.publicVideo = videoNameEnum.leftVideo;
                      //  Debug.Log("bRightVideo_01: " + gameObject.name);
                        yield return new WaitForSeconds(0.1f);
                    }
                  else  if (bLeftVideo_02 && playVideo.publicVideo == videoNameEnum.init)
                    {
                        p6_secondPlayVideo_2.SetActive(false);
                        yield return null;
                        //  leftVideoObject.SetActive(true);
                        yield return null;
                        playVideo.publicVideo = videoNameEnum.rightVideo;
                      //  Debug.Log("bRightVideo_01: " + gameObject.name);
                        yield return new WaitForSeconds(0.1f);
                    }
                  else  if (bLeftCloseVideo)
                    {
                        p6_secondPlayVideo_2.SetActive(true);
                        yield return null;
                        playVideo.bCloseVideo = true;
                    }
                    //这是关闭的视频；走向下一步；也是接下来所有下一步的控制变量；
                    if (bLeftPlayed == true)
                    {
                        Debug.Log(" _fps.bFinished");
                        _fps.bFinished = true;
                        Debug.Log("videoNextStep: " + gameObject.name);

                        yield return new WaitForSeconds(0.1f);
                    }
                    //接下来是第二个场景的；
                    #endregion
                }
                else if (gameObject.name == "Controller (right)")
                {
                    #region p4UI弹框的问题；

                    if (bLeftP4Right_01 ||bLeftP4Right_02 || bLeftP4Right_03)
                    {
                        if (bLeftP4Right_01)
                        {
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_1 == false)
                            {
                                //    Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                                bCheckOvering = true;
                                bCheckOvering_1 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.right;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.right;

                                bMovingP4 = true;
                            }
                            else if (bCheckOvering == true && bMovingP4 == false && bCheckOvering_1 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.right;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.right;

                                bCheckOvering_1 = false;
                                bMovingP4 = true;
                            }
                        }

                        if (bLeftP4Right_02)
                        {
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_2 == false)
                            {
                                bCheckOvering = true;
                                bCheckOvering_2 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.mid;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.mid;

                                bMovingP4 = true;
                            }
                            else if (bCheckOvering == true && bMovingP4 == false && bCheckOvering_2 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.mid;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.mid;

                                bCheckOvering_2 = false;
                                bMovingP4 = true;
                            }
                        }

                        if (bLeftP4Right_03)
                        {
                            //  Debug.Log("bLeftP4Right_03");
                            if (bCheckOvering == false && bMovingP4 == false && bCheckOvering_3 == false)
                            {
                                //   Debug.Log("bLeftP4Right_03");
                                bCheckOvering = true;
                                bCheckOvering_3 = true;
                                yield return null;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.left;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.left;
                                bMovingP4 = true;
                            }
                            else if (bCheckOvering == true && bMovingP4 == false && bCheckOvering_3 == true)
                            {
                                //这是在返回去；
                                bCheckOvering = false;
                                if (_fps.room == roomEnum.firstRoom)
                                    p4move.publicUIposi = UIposiEnum.left;
                                else if (_fps.room == roomEnum.thirdRoom)
                                    p10move.publicUIposi = UIposiEnum.left;

                                bCheckOvering_3 = false;
                                bMovingP4 = true;
                            }
                        }
                    }
                    //else
                    //{
                    //    if (bCheckOvering == true && bMovingP4 == false)
                    //    {
                    //        // Debug.Log("bLeftP4Left_02 " + Time.time);
                    //        bCheckOvering = false;
                    //        if (true == bCheckOvering_1)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.right;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.right;
                    //            bCheckOvering_1 = false;
                    //        }

                    //        if (true == bCheckOvering_2)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.mid;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.mid;
                    //            bCheckOvering_2 = false;
                    //        }

                    //        if (true == bCheckOvering_3)
                    //        {
                    //            if (_fps.room == roomEnum.firstRoom)
                    //                p4move.publicUIposi = UIposiEnum.left;
                    //            else if (_fps.room == roomEnum.thirdRoom)
                    //                p10move.publicUIposi = UIposiEnum.left;
                    //            bCheckOvering_3 = false;
                    //        }

                    //        yield return new WaitForSeconds(0.1f);
                    //        bMovingP4 = true;
                    //    }
                    //}

                    #endregion

                    if (bRightMigrate)
                    {
                        _fps.bMigrate = true;
                    }

                    //下面处理视频暂停的问题；
                    if (bRightPlay == true)
                    {
                        //Debug.Log("bRightPlay" + gameObject.name);
                        if (playVideo.bPause == true)
                        {
                            playVideo.bStartPause = true;
                            //     playVideo.bPause = !playVideo.bPause;
                            yield return new WaitForSeconds(0.2f);
                            playVideo.bPause = false;
                            yield return new WaitForSeconds(0.2F);
                            playVideo.bStartPause = false;
                            yield return new WaitForSeconds(0.3f);

                        }
                        else
                        {
                            playVideo.bPause = true;
                            yield return new WaitForSeconds(0.3f);
                        }


                    }
                    //    Debug.Log(gameObject.name + "lihaifeng") ;

                    #region OK
                    //用于第一个房间到第二个房间的按钮；
                    if (bRightFirstClick == true)
                    {
                        _fps.bFinished = true;

                       // Debug.Log("click: " + gameObject.name);
                        yield return new WaitForSeconds(2);
                    }
                    //用于检查按钮；
                    if (bRightCheckNet == true)
                    {
                        _fps.bCheckNet = true;
                      //  Debug.Log("bRightCheckNet: " + gameObject.name);
                        yield return new WaitForSeconds(2);
                    }


                    //打开左边的的1号视频；
                    if (bRightVideo_01 && playVideo.publicVideo == videoNameEnum.init)
                    {
                        p6_secondPlayVideo_2.SetActive(false);
                        yield return null;
                        //     rightVideoObject.SetActive(true);
                        yield return null;
                        playVideo.publicVideo = videoNameEnum.leftVideo;
                     //   Debug.Log("bRightVideo_01: " + gameObject.name);
                        yield return new WaitForSeconds(0.1f);
                    }
                   else  if (bRightVideo_02 && playVideo.publicVideo == videoNameEnum.init)
                    {

                        p6_secondPlayVideo_2.SetActive(false);
                        yield return null;
                        //     rightVideoObject.SetActive(true);
                        yield return null;
                        playVideo.publicVideo = videoNameEnum.rightVideo;
                     //   Debug.Log("bRightVideo_01: " + gameObject.name);
                        yield return new WaitForSeconds(0.1f);
                    }
                    //接下来是第二个场景的；
                    if (bRightCloseVideo)
                    {
                        p6_secondPlayVideo_2.SetActive(true);
                        yield return null;

                        playVideo.bCloseVideo = true;
                    }

                    //这是关闭的视频；走向下一步；
                    if (bRightPlayed == true)
                    {
                      //  Debug.Log(" _fps.bFinished");
                        _fps.bFinished = true;
                        
                     //   Debug.Log("videoNextStep: " + gameObject.name);
                        yield return new WaitForSeconds(0.1f);
                    }
                    #endregion
                }
            }
            //返回键被按下；
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                if (bBack == false)
                {
                    bBack = true;
                    string str = getPath();
                    str = str + callName;
                    Debug.Log(str + gameObject.name);

                    System.Diagnostics.Process.Start(str);

                    Application.Quit();
                    yield return new WaitForSeconds(10);
                    break;
                }

                // press2return.returnFun(str);
            }

            if(bAgainPlay == true)
            {
                Application.LoadLevel(0);
            }

            yield return null;

          //  Debug.Log("gangGe");
        }
     //   Debug.Log("lihaifeng");

     //   Debug.Log("break");
        yield return null;
    }

    public static bool bReset = false;

    public static bool bAgainPlay = false;

    //被调用的exe名字；
    public string callName;
    //本exe名字；
    public  string selfFileName = "SDH_en";

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
