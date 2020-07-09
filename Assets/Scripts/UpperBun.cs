using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBun : MonoBehaviour
{
    //Down check
    public  Transform DownCheck;
    public LayerMask WhatIsDownLayer;
    //Colliders
    Collider2D[] colliders;	

    private void FixedUpdate()
	{
        Vector2 point = DownCheck.position;
        Vector2 size = new Vector2(1.3f, 0.01f);
        float angle = gameObject.transform.rotation.eulerAngles.z;

        DebugDrawBox(point, size, angle, Color.cyan, 0.01f);
		colliders = Physics2D.OverlapBoxAll(point, size, angle, WhatIsDownLayer);
		if(colliders.Length == 0){
            Buns.isUpperBunTouchingTopping = false;
        }else{
            for (int i = 0; i < colliders.Length; i++){
                if (colliders[i].gameObject.tag == "Topping" || colliders[i].gameObject.tag == "FirstMeat")
                {
                    Buns.isUpperBunTouchingTopping = true;
                }
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool isInArray = false;
        if(colliders.Length != 0){
            for (int i = 0; i < colliders.Length; i++){
                if (colliders[i].gameObject == collision.gameObject)
                {
                    isInArray = true;
                }
            }
        }
        if(!isInArray){
            GameEvents.current.GameOver();
        }
    }

    void DebugDrawBox( Vector2 point, Vector2 size, float angle, Color color, float duration) {

        var orientation = Quaternion.Euler(0, 0, angle);

        // Basis vectors, half the size in each direction from the center.
        Vector2 right = orientation * Vector2.right * size.x/2f;
        Vector2 up = orientation * Vector2.up * size.y/2f;

        // Four box corners.
        var topLeft = point + up - right;
        var topRight = point + up + right;
        var bottomRight = point - up + right;
        var bottomLeft = point - up - right;

        // Now we've reduced the problem to drawing lines.
        Debug.DrawLine(topLeft, topRight, color, duration);
        Debug.DrawLine(topRight, bottomRight, color, duration);
        Debug.DrawLine(bottomRight, bottomLeft, color, duration);
        Debug.DrawLine(bottomLeft, topLeft, color, duration);
    }

}
