using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button creditsOpen;
    [SerializeField] private Button creditsClose;
    [SerializeField] private GameObject creditsUI;
    [SerializeField] private Button platformerOpen;
    [SerializeField] private Button SpawnButtonOpen;
    [SerializeField] private Button PongButton;
    [SerializeField] private Button FPSButton;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        creditsOpen.onClick.AddListener(() => { creditsUI.SetActive(true); });
        creditsClose.onClick.AddListener(() => { creditsUI.SetActive(false); });
        startButton.onClick.AddListener(() => LoadingScreen.LoadScene("GunScene"));
        platformerOpen.onClick.AddListener(() => LoadingScreen.LoadScene("NotAnotherPlatformer"));
        SpawnButtonOpen.onClick.AddListener(() => LoadingScreen.LoadScene("3DSpawn"));
        PongButton.onClick.AddListener(() => LoadingScreen.LoadScene("Pong"));
        FPSButton.onClick.AddListener(() => LoadingScreen.LoadScene("FPS"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
