using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    CinemachineBasicMultiChannelPerlin noise;
    public float shakeTime = 1.0f;
    public float amplitude = 1.0f;

    public float waveTime = 1.0f;
    public float waveAmplitude = 1.0f;
    private float timer = 0.0f;

    public bool waveShaking = false;
    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shake(shakeTime,amplitude));
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
           waveShaking=true;
        }
        if(waveShaking)
        {
            timer += Time.deltaTime;
            noise.m_AmplitudeGain = Mathf.Lerp(0, waveAmplitude, timer/waveTime);
            if(timer > waveTime) 
            {
                noise.m_AmplitudeGain = Mathf.Lerp(waveAmplitude, 0, (timer - waveTime) / waveTime);
            }
            if(timer>waveTime *2)
            {
                timer = 0;
                waveShaking = false;
            }
        }
    }

    IEnumerator Shake(float duration, float maxAmp)
    {
        noise.m_AmplitudeGain = maxAmp;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
    }
}
