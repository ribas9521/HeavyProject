using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    public GameObject TouchedObject()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = new RaycastHit2D();
        if (Input.GetMouseButtonDown(0))
        {

            hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                return hit.transform.gameObject;

            }
            else
                return null;
        }
        else
            return null;
    }

    


    public RaycastHit2D[] TouchedObjectB(Vector2 pos)
    {
        Vector2 newPos = Camera.main.ScreenToWorldPoint(pos);
        RaycastHit2D[] hits = null;        

        hits = Physics2D.LinecastAll(newPos,newPos);           

        
        return hits;
        
    }

    public List<RaycastHit2D> TouchedGO(string tag)
    {
        List<RaycastHit2D> resp = new List<RaycastHit2D>();
        if (Input.touchCount > 0)
        {            
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {                    
                    case TouchPhase.Moved:
                        RaycastHit2D[] temp = TouchedObjectB(touch.position);
                        if (temp != null)
                        {
                            foreach (var item in temp)
                            {
                                if (item.transform.CompareTag("Monster"))
                                {
                                    print(item.collider.name);
                                    resp.Add(item);
                                }
                            }
                            
                        }
                        break;
                }
            }
            
        }
        return resp;
    }
  
    public Vector2 TouchedObjectPoint()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = new RaycastHit2D();
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                return hit.point;

            }           
        }
        return Vector2.zero;
    }

    public void SwipedObject()
    {       
        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                //swipe orizontal
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                               
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                                
                                

                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                }
                                else
                                {
                                    // MOVE LEFT
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                }
                                else
                                {
                                    // MOVE DOWN
                                }
                            }

                        }

                        break;
                }
            }
        }

    }
}
