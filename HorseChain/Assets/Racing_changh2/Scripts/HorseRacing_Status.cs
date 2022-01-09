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
        public float speed , accel , hp , agility , consistency;
        public Status(float s,float a,float h,float ag,float c)
        {
            this.speed = s;
            this.accel = a;
            this.hp = h;
            this.agility = ag;
            this.consistency = c;
        }
    }
    Dictionary<string,bool> horseLocation = new Dictionary<string, bool>();
    Status horseStatus;

    bool isHalf; // 레일의 절반을 뛰었는지 판단
    float rotateTime;
    // 회전에 필요한 변수 및  오브젝트
    float radius;
    bool isRotate;
    public GameObject round1,round2;
    Vector3 startPosition;
    void Start()
    {
        AddLocation();
        horseStatus = new Status(2.0f,1.0f,1.0f,1.0f,1.0f);
        isHalf =false;
        isRotate =false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        Run();
    }

    void Run()
    {
        Vector3 currentPosition = transform.position;

        if(currentPosition.x >= 38  && !isRotate)
        {
            isRotate = true;
            isHalf = true;
            radius = Vector3.Distance( currentPosition , round1.transform.position);
            startPosition = currentPosition;
            Debug.Log("헤이");
        }
        else if(currentPosition.x <= -42 && isHalf && !isRotate)
        {
            isRotate = true;
            radius = Vector3.Distance( currentPosition , round2.transform.position);
            startPosition = currentPosition;
            Debug.Log("헤2이");
        }
        else if(isRotate)
        {
            Rotate();
        }
        else if(currentPosition.x > -22 && currentPosition.x <= 38 && !isHalf && !isRotate)
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        new Vector3(38,currentPosition.y,currentPosition.z),10f*horseStatus.speed* Time.deltaTime);
            rotateTime=0;
            isRotate=false;
            Debug.Log("헤3이");
        }
        else if(currentPosition.x > -22 && currentPosition.x <= 38 && isHalf && isRotate)
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        new Vector3(-22,currentPosition.y,currentPosition.z),10f*horseStatus.speed* Time.deltaTime); 
            rotateTime=0;
            isRotate=false;
            Debug.Log("헤4이");
        }
    }
    void DecisionMake()
    {

    }
    void Rotate()
    {
        Vector3 currentPosition = transform.position;

        if(isHalf)
        {
            rotateTime += horseStatus.speed* Time.deltaTime * 0.5f ;
            float z = radius * Mathf.Cos(rotateTime);
            float x = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3(round1.transform.position.x -x,startPosition.y, (round1.transform.position.z -z));
        }
        else if(!isHalf)
        {
            rotateTime += horseStatus.speed* Time.deltaTime * 0.5f ;
            float z = radius * Mathf.Cos(-rotateTime);
            float x = radius * Mathf.Sin(rotateTime);
            transform.position = new Vector3(round2.transform.position.x -x,startPosition.y, (round2.transform.position.z +z));
        }

    }

    void AddLocation(){
        horseLocation.Add("First",true);
        horseLocation.Add("Second",false);
        horseLocation.Add("Third",false);
        horseLocation.Add("Fourth",false);
    }
}
