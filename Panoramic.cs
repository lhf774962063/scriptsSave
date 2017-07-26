using UnityEngine;
using System.Collections;

public class MovieView : MonoBehaviour {

    public MovieTexture movTexture;

    
    public GameObject musicObject;
    AudioSource music;
    void Start()
    {
        music = musicObject.GetComponent<AudioSource>();
      //  _PublicAPI.ClearConsole();

        //设置当前对象的主纹理为电影纹理
        // renderer.material.mainTexture = movTexture;

        gameObject.GetComponent<Renderer>().material.mainTexture = movTexture;
        //设置电影纹理播放模式为循环
        movTexture.loop = true;

        if (!movTexture.isPlaying)
        {
            movTexture.Play();
            music.Play();
        }
    }



    void Update()
    {
        if(hand.bBack == true)
        {
            movTexture.Pause();
            music.Pause();
            hand.bBack = false;
        }
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    if (!movTexture.isPlaying)
        //    {
        //        movTexture.Play();
        //          music.Play();
        //    }
        //    else if(movTexture.isPlaying)
        //    {
        //        movTexture.Pause();
        //        music.Pause();
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    if (movTexture.isPlaying)
        //    {
        //        movTexture.Stop();
        //        music.Stop();
        //    }
        //}
    }

    void OnGUI()
    {
        //if (GUILayout.Button("播放/继续"))
        //{
        //    //播放/继续播放视频
        //    if (!movTexture.isPlaying)
        //    {
        //        movTexture.Play();
        //    }

        //}

        //if (GUILayout.Button("暂停播放"))
        //{
        //    //暂停播放
        //    movTexture.Pause();
        //}

        //if (GUILayout.Button("停止播放"))
        //{
        //    //停止播放
        //    movTexture.Stop();
        //}
    }
}
