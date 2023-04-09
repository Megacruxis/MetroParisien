using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public string pauseButton;
    bool isActive = false;
    float lastTimeValue = 1;
    public bool menuPause = false;
    public AudioSource audioSource;
    public AudioClip valideSound;

    [Header("Cinematic Start")]
    [SerializeField] private List<GameObject> objectsToDisable;
    [SerializeField] private List<GameObject> objectsToEnable;
    [SerializeField] private float timeBeforeTransition;
    [SerializeField] private EventReference menuSoundEvent;
    FMOD.Studio.EventInstance menuSoundInstance;
    [SerializeField] private EventReference startSoundEvent;
    FMOD.Studio.EventInstance startSoundInstance;
    //[SerializeField] private string sceneToLoad;

    private void Awake()
    {
        menuSoundInstance = RuntimeManager.CreateInstance(menuSoundEvent);
        startSoundInstance = RuntimeManager.CreateInstance(startSoundEvent);
    }


    public void StartCinematic(string sceneToLoad)
    {
        StartCoroutine(StartGame(sceneToLoad));
    }

    public IEnumerator StartGame(string sceneToLoad)
    {
        menuSoundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //yield return new WaitForSeconds(timeBeforeTransition);
        foreach (var item in objectsToDisable)
        {
            item.SetActive(false);
        }
        foreach (var item in objectsToEnable)
        {
            item.SetActive(true);
        }
        startSoundInstance.start();
        yield return new WaitForSeconds(timeBeforeTransition);
        SceneManager.LoadScene(sceneToLoad);

    }

    public void SetPauseOnOff()
    {
        if (isActive)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = lastTimeValue;
            isActive = false;
            //audioSource.PlayOneShot(valideSound);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pauseMenu.SetActive(true);
            lastTimeValue = Time.timeScale;
            Time.timeScale = 0;
            isActive = true;
            //audioSource.PlayOneShot(valideSound);
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    public void CloseApli()
    {

        Application.Quit();

    }

    public void Open_CloseMenu(GameObject menu)
    {
        menu.SetActive(!menu.activeInHierarchy);
    }
    // Start is called before the first frame update
    void Start()
    {
        menuSoundInstance.start();
        if (menuPause)
        {
            pauseMenu.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown(pauseButton) && menuPause)
        {
            SetPauseOnOff();
        }*/
        //Debug.Log(Time.timeScale);
    }
}
