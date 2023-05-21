using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public Text score; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "S c o r e :  " + PlayerController.points;
    }
}
