using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{

    public Button restart_button;
    // Start is called before the first frame update
    void Start()
    {
        restart_button.onClick.AddListener(()=>SceneManager.LoadScene("StartScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
