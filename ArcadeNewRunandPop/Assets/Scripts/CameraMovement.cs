using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Movespeed = 7f;
    public float smoothSpeed = 2f;

    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public bool iscamerareached;
    public GameManager GM;
    public GameObject Ball;

    private float xPos, yPos;
    private Vector3 targetTemp;

    void Awake()
    {
        isMoving = false;
        iscamerareached = false;
        targetTemp = new Vector3(0f, 0f, -10f);
    }
    void LateUpdate()
    {
        //if(!GM.isGameover)
        //{
        //    xPos = Ball.transform.position.x;
        //    yPos = Ball.transform.position.y;
        //}
        
        //if (GM.LoadLevel >= 5 && isMoving == false)
        //{
        //    if (yPos >= 2f && yPos < 7.5f && iscamerareached == false)
        //    {                
        //        targetTemp.y = 4.5f;
        //        isMoving = true;
        //        iscamerareached = true;
        //    }
        //}

        if(isMoving)
        {
            float step = Movespeed * Time.deltaTime;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetTemp, smoothSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, smoothedPosition, step);
            if(transform.position == targetTemp)
            {
                isMoving = false;
            }
        }
    }


    public IEnumerator MoveCamTo()
    {
        yield return new WaitForSeconds(0.1f);
        if(Ball.transform.position.y >= 0f)
        {
            targetTemp.y = Ball.transform.position.y + 1f;
            isMoving = true;
        }
    }
}
