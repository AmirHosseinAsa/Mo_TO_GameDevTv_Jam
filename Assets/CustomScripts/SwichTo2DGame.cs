using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichTo2DGame : MonoBehaviour
{

    public Transform Player;

    void OnMouseOver()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (Input.GetMouseButtonDown(0) && dist < 15)
                SwitchTo2D();
        }

    }

    void SwitchTo2D()
    {
        Debug.Log("Swich to 2D");
        SceneManager.LoadScene(1);
    }
}
