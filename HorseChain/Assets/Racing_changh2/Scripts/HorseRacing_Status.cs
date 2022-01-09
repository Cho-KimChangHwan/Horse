using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRacing_Status : MonoBehaviour
{
    // 경기장 일직선 코스 시작 : -42 ~ 38 총 길이 80 
    // Start is called before the first frame update

    // 말의 능력치를 저장
    public struct Status
    {
        public int speed , accel , hp , agility , consistency;
        public Status(int s,int a,int h,int ag,int c)
        {
            this.speed = s;
            this.accel = a;
            this.hp = h;
            this.agility = ag;
            this.consistency = c;
        }
    }
    bool ishalf; // 레일의 절반을 뛰었는지 판단
    void Start()
    {
        ishalf = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        run();
    }

    void run()
    {
        Vector3 currentPosition = transform.position;
        if(currentPosition.x > -22 && currentPosition.x < 18 && !ishalf)
        {
            transform.position = Vector3.MoveTowards(transform.position , 
                                        new Vector3(18,currentPosition.y,currentPosition.z),0.15f);
        }
        else if(currentPosition.x > -22 && currentPosition.x < 18 && ishalf)
        {
            transform.position = Vector3.MoveTowards(transform.position , 
                                        new Vector3(-22,currentPosition.y,currentPosition.z),0.1f); 
        }
        /*
        else if()
        {

        }
        else if()
        {
            
        */
        
    }
}
