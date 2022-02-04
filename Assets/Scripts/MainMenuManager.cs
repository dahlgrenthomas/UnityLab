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

    // Start is called before the first frame update
    void Start()
    {
        creditsOpen.onClick.AddListener(() => { creditsUI.SetActive(true); });
        creditsClose.onClick.AddListener(() => { creditsUI.SetActive(false); });
        startButton.onClick.AddListener(() => LoadingScreen.LoadScene("GunScene"));
        platformerOpen.onClick.AddListener(() => LoadingScreen.LoadScene("NotAnotherPlatformer"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
