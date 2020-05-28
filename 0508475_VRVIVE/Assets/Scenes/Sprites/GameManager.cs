using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //引用場景管理器API
using Valve.VR.InteractionSystem; //引用VR互動API

public class GameManager : MonoBehaviour
{
    [Header("寶石數量")]
    public Text textGamCount;
    [Header("分數")]
    public Text textScore;
    [Header("得分音效")]
    public AudioClip soundScore;

    private AudioSource aud;
    private int gamcount = 5;
    private int score;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    public void UseGam(GameObject gam)
    {
        //刪除(寶石.取得元件<丟擲>())
        //刪除(寶石.取得元件<互動>())
        Destroy(gam.GetComponent<Throwable>());
        Destroy(gam.GetComponent<Interactable>());

        //數量遞減
        gamcount--;
        //更新文字
        textGamCount.text = "寶石數量：" + gamcount + "/5";
    }

    private void OnTriggerEnter(Collider other)
    {
        //分數遞增
        score +=2;
        //更新文字
        textScore.text = "分數：" + score;
        //播放音效
        aud.PlayOneShot(soundScore, 0.5f);
    }
    public void Replay()
    {
        //刪除(玩家.遊戲物件)
        Destroy(FindObjectOfType<Player>().gameObject);
        //場景管理器.載入場景("場景名稱")
        SceneManager.LoadScene("找寶石");
    }
    public void Quit()
    {
        //應用程式.離開遊戲()  適用於PC、手機
        Application.Quit();
    }
}
