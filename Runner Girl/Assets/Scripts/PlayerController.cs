using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;

    float touchXdelta = 0;
    float newX=0;
    public float xspeed;
    public float limitX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      SwipeCheck();

        
    }

    public void SwipeCheck()
    {
        
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXdelta = Input.GetTouch(0).deltaPosition.x/Screen.width;
            Debug.Log("TIKLANDI TELEFONA");
            
        }
        else if (Input.GetMouseButton(0))
        {
            touchXdelta = Input.GetAxis("Mouse X");
            Debug.Log("TIKLANDI");
            
        }
        newX = (transform.position.x + xspeed* touchXdelta*Time.deltaTime);
        newX = Mathf.Clamp(newX, -limitX, limitX);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
