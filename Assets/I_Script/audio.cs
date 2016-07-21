using UnityEngine;
using System.Collections;

public class audio : MonoBehaviour {
    public GUISkin ChineseSkin;
    public AudioSource[] MyAudio;
    public string[] SongNames;
    public string[] SongerNames;
    int SongIndex = 0;
    bool LoopPlay = true;
    

	// Use this for initialization
	void Start () {
        while (!MyAudio[SongIndex].isPlaying)
        {
            if (SongIndex == MyAudio.Length)
            {
                SongIndex = 0;
                MyAudio[SongIndex].Play();
            }
        }


    }
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnGUI()
    {
        GUI.skin = ChineseSkin;

     
           

            if (GUI.Button(new Rect(10, 10, 50, 30), "开始"))
            {

                MyAudio[SongIndex].Play();

                if (SongIndex < MyAudio.Length)
                {
                   
                    MyAudio[SongIndex].Play();
                
               }          
            
             }
            if (GUI.Button(new Rect(70, 10, 50, 30), "暂停"))
            {
                MyAudio[SongIndex].Pause();
            }
            if (GUI.Button(new Rect(130, 10, 50, 30), "停止"))
            {
                MyAudio[SongIndex].Stop();
            }
            if (GUI.Button(new Rect(190, 10, 60, 30), "上一首"))
            {
                for (int i = 0; i < MyAudio.Length; i++)
                {
                    if (MyAudio[i].isPlaying)
                    {
                        MyAudio[i].Stop();
                    }

                }
                if (SongIndex > 0)
                    SongIndex--;
                else if (LoopPlay)
                    SongIndex = MyAudio.Length - 1;
                MyAudio[SongIndex].Play();

            }
            if (GUI.Button(new Rect(260, 10, 60, 30), "下一首"))
            {
                if (MyAudio[SongIndex].isPlaying)
                {
                    MyAudio[SongIndex].Stop();
                }
                if (SongIndex < MyAudio.Length - 1)
                    SongIndex++;
                else if (LoopPlay)
                    SongIndex = 0;
                MyAudio[SongIndex].Play();
            }

        

        //GUI.contentColor = Color.red;
        //LoopPlay = GUI.Toggle(new Rect(10, 45, 80, 30),LoopPlay , "循环播放");

        GUI.Label(new Rect(10, 80, Screen.width, 30), "当前歌曲名称" + SongNames[SongIndex]);
        GUI.Label(new Rect(10, 115, Screen.width, 30), "歌手姓名" + SongerNames[SongIndex]);
        GUI.contentColor = Color.white;
    }

    
}
