using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PowerUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int food = 0;
    public Slider slider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food") {
            food = food + 1;
            Destroy(other.gameObject);
        }
     }
    void Update()
    {
        slider.value = food;
    }



    public bool DoubbleJumpAsk()
    {
        if (food > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoubbleJumpDone()
    {
        food = food - 1;
        return true;
    }

}
