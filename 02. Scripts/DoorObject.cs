using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour {
    // 문 관련 변수
    public bool DoorSwitch;
    private Animation DoorAni;

    // 폭발음 오디오 클립 (왼쪽 문에 AudioSource 넣음)
    private AudioSource _audio;
    public AudioClip expSfx;

    // Use this for initialization
    void Start()
    {
        DoorAni = GetComponent<Animation>();
        DoorSwitch = false;
        // AudioSource 컴포넌트를 추출해 저장
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (DoorSwitch == true)
        {
            // 폭발음 발생
            Debug.Log("Sound on!!");
            _audio.PlayOneShot(expSfx, 1.0f);
            Debug.Log("DoorAni Play!!!");
            DoorAni.Play();
            DoorSwitch = false;
        }
    }
}
