using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pic = 0; 
    private int canon = 0; 
    [SerializeField] private GameObject picItem; 
    [SerializeField] private GameObject canonItem; 
    
    //Détection de la collision avec un obstacle et désactivation de celui-ci
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test" + collision.gameObject.layer);
        Debug.Log("test" + collision.gameObject.name);
        if (collision.gameObject.layer == 6)
        {
           
            collision.gameObject.SetActive(false);
        }
    }*/
   
    private void OnTriggerEnter2D(Collider2D collision){
 
        if(collision.gameObject.CompareTag("Pic")){
            if(pic == 0){
                pic+=1; 
                if(collision.transform.gameObject.layer == 6){
                    collision.gameObject.SetActive(false);
                }
                picItem.SetActive(true);
               
               
            }
            
        }
        if(collision.gameObject.CompareTag("Canon")){
            if(canon == 0){
                canon+=1; 
                
                canonItem.SetActive(true);
                if(collision.transform.gameObject.layer == 6){
                    collision.gameObject.SetActive(false);
                }
                Debug.Log("canon" + canon);
            }
            Debug.Log("canon" + canon);

        }

    }


    private void UseItem(){
        if(pic == 0){
            Debug.Log("pas de pic");
        }else{
            picItem.SetActive(false); 
        }

         if(canon == 0){
            Debug.Log("pas de canon");
        }else{
            canonItem.SetActive(false); 
        }

    }
}
