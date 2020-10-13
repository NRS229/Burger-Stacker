using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestingArt : MonoBehaviour
{
    public static GameObject[] burgerParts;
    public static GameObject upperBun;
    public static GameObject lowerBun;
     
    void Start(){
        
        burgerParts = Resources.LoadAll<GameObject>("Prefabs");
        upperBun = Resources.Load<GameObject>("Prefabs/UpperBun");
        lowerBun = Resources.Load<GameObject>("Prefabs/LowerBun");

        RemoveBunsFromArray();

        //i loop
        for(int i=0; i< burgerParts.Length; i++){
            //j loop
            for(int j=0; j< burgerParts.Length; j++){
                instantiatePart(lowerBun, i*2, j*2, 1); // Instantiate LowerBun
                instantiatePart(burgerParts[j], i*2, j*2, 2); // Instantiate Topping
                instantiatePart(burgerParts[i], i*2, j*2, 3); // Instantiate Topping
                instantiatePart(upperBun, i*2, j*2, 4); // Instantiate UpperBun
            }
        }
    }

    void instantiatePart(GameObject part, int i, int j, int sortingOrder){
        GameObject partInstantiated = Instantiate (part) as GameObject; //instantiate the part
        partInstantiated.transform.position = new Vector2(i, j); //position of the part
        partInstantiated.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        if(part == lowerBun){ // Delete Rigidbody2D from lowerBun
            UnityEngine.Object.Destroy(partInstantiated.GetComponent<Rigidbody2D>()); 
        }
    }

    void RemoveBunsFromArray(){
        List<GameObject> list = new List<GameObject>(burgerParts);
        for(int n=0; n< list.Count; n++){
            if((list[n] == upperBun) || (list[n] == lowerBun)){
                list.RemoveAt(n);
            }
        }
        burgerParts = list.ToArray();
    }

}
