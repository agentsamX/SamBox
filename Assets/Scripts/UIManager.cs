using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject spinButton;

    public ParticleSystem ParticleSystem1;
    public ParticleSystem ParticleSystem2;
    public ParticleSystem ParticleSystem3;
    public ParticleSystem ParticleSystem4;


    private bool spin = false;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if(spin)
        {
            spinButton.transform.Rotate(0, 0, 100.0f*Time.unscaledDeltaTime);
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void Spin()
    {
        spin = !spin;
        spinButton.transform.eulerAngles = Vector3.zero;
    }
    public void StartParticle1()
    {
        ParticleSystem1.Play();
    }
    public void StartParticle2()
    {
        ParticleSystem2.Play();
    }
    public void StartParticle3()
    {
        ParticleSystem3.Play();
    }
    public void StartParticle4()
    {
        ParticleSystem4.Play();
    }
}
