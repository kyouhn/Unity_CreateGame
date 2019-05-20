using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    //りんごをキャッチできたときに加算するメソッド
    public void GetApple()
    {
        this.point += 100;
    }

    //ボムをキャッチしたときに減算するメソッド
    public void GetBomb()
    {
        this.point /= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム間の時間の差分を減算
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                    10000.0f, 0, 0);
            if (this.point >= 2000)
            {

            }
        }else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                0.7f, -0.04f, 3);
        }else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                0.5f, -0.05f, 6);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                0.8f, -0.04f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(
                1.0f, -0.03f, 2);
        }

        //制限時間
        this.timerText.GetComponent<Text>().text=
            this.time.ToString("F1");

        this.pointText.GetComponent<Text>().text =
            this.point.ToString() + " point";
    }
}
