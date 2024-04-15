using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
 
 public void startGame(){
    SceneManager.LoadScene(1);       
 }

    public void level1()
    {
        SceneManager.LoadScene(2);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

}
