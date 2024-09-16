using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour//Singleton<MonoBehaviour>
{

    public static SoundManager Instance;
    public enum SoundType
    {
        Click,
        GetBullet,
        Fire,
        // ... other sound types
    }
    public AudioSource speaker_A;
    public AudioSource speaker_B;
    public AudioSource speaker_C;
    public AudioSource speaker_D;
    public AudioSource speaker_E;
    public AudioSource speaker_BGM;


    // ... (기존의 AudioSource 및 AudioClip 변수들)

    public AudioClip Tooltipsound;
    public AudioClip clickSound;
    public AudioClip getBulletSound;
    public AudioClip EFireSound;
    public AudioClip TH1BossFireSound;
    public AudioClip TH1BossAtk1Sound;
    public AudioClip TH1CubeDropSound;
    public AudioClip TH1CubeDrop2Sound;



    public AudioClip damagedBoxSound;
    public AudioClip GoalinSound;
    public AudioClip WarpUpSound;
    public AudioClip gameoverSound;
    public AudioClip stageclearSound;
    public AudioClip roundresultSound;
    public AudioClip ShotSound;
    public AudioClip ShotSound1;
    public AudioClip HitBlockSound;
    public AudioClip Bulletblocksound;
    public AudioClip PlayerdieSound;
    public AudioClip PlayerwalkSound;
    public AudioClip ShieldSound;
    public AudioClip startani;
    public AudioClip[] BGMarray = new AudioClip[4];

    public AudioClip E1Atksnd;
    public AudioClip E1Deadsnd;
    public AudioClip E2Atksnd;
    public AudioClip E2Deadsnd;
    public AudioClip E3Atksnd;
    public AudioClip E3Deadsnd;
    //---   언에이블 일렉홀 . 전기 함정 무효화 
    public AudioClip UnenableElesound;


    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundType soundType;
        public AudioClip audioClip;
    }

    public SoundAudioClip[] soundAudioClipArray;

    private Dictionary<SoundType, AudioClip> soundAudioClips;
    private AudioSource audioSource;


    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        soundAudioClips = new Dictionary<SoundType, AudioClip>();
        foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
        {
            soundAudioClips[soundAudioClip.soundType] = soundAudioClip.audioClip;
        }


        if (soundAudioClipArray != null)
        {
            foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
            {
                if (soundAudioClip != null)
                {
                    soundAudioClips[soundAudioClip.soundType] = soundAudioClip.audioClip;
                }
            }
        }

        audioSource = GetComponent<AudioSource>();

    }




    /*  void Awake()
    {
      if (this == null)
        {
            this.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
    void Start()
    {
        // if(GameManager.nLevel >= 0)
        // PlayBackgroundMusic(GameManager.nLevel);

    }

    public void E1Dead() => PlaySound(E1Deadsnd, speaker_A);
    public void Click() => PlaySound(clickSound, speaker_A);
    public void Getbullet() => PlaySound(getBulletSound, speaker_B);


    public void PlaySound(AudioClip clip, AudioSource source, float volume = 1.0f)
    {
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }



    public void PlaySound(SoundType soundType)
    {
        if (soundAudioClips.ContainsKey(soundType))
        {
            audioSource.PlayOneShot(soundAudioClips[soundType]);
        }
    }

    public void playTooltipsound()
    {
        speaker_C.clip = Tooltipsound;
        speaker_C.Play();
    }


    public void Goalin()
    {
        speaker_D.clip = GoalinSound;
        speaker_D.Play();
    }
    public void WarpUp()
    {
        speaker_E.clip = WarpUpSound;
        speaker_E.Play();
    }


    public void Fire()
    {
        speaker_A.clip = ShotSound;
        speaker_A.Play();
    }
    public void Fire1()
    {
        speaker_D.clip = ShotSound1;
        speaker_D.Play();
    }


    public void StageClear()
    {
        speaker_B.clip = stageclearSound;
        speaker_B.Play();
    }
    public void GameOver()
    {
        speaker_C.clip = gameoverSound;
        speaker_C.Play();
    }


    public void Playerdie()
    {
        speaker_D.clip = PlayerdieSound;
        speaker_D.Play();
    }


    public void DamagedBox()
    {
        speaker_A.clip = damagedBoxSound;
        speaker_A.Play();
    }


    public void Bulletblock()
    {
        speaker_B.clip = Bulletblocksound;
        speaker_B.Play();
    }


    public void EnemyFire()
    {
        speaker_C.clip = EFireSound;
        speaker_C.Play();
    }


    public void Playerwalks()
    {
        speaker_D.clip = PlayerwalkSound;
        speaker_D.Play();
    }


    public void RoundResult()
    {
        speaker_A.clip = roundresultSound;
        speaker_A.Play();
    }


    public void UnenableElecHole()
    {
        speaker_B.clip = UnenableElesound;
        speaker_B.Play();
    }


    public void Shiled()
    {
        speaker_C.clip = ShieldSound;
        speaker_C.Play();
    }
    public void TH1Bossfire()
    {
        speaker_D.clip = TH1BossFireSound;
        speaker_D.Play();
    }

    public void TH1CubeDrop1()
    {
        speaker_E.clip = TH1CubeDropSound;
        speaker_E.Play();
    }
    public void BG_AmdientSound0()
    {
        speaker_A.clip = BGMarray[0];
        speaker_A.Play();
    }
    public void BG_AmdientSound1()
    {
        speaker_E.clip = BGMarray[1];
        speaker_E.volume = 0.2f;
        speaker_E.Play();
    }
    public void BG_AmdientSound2()
    {
        speaker_B.clip = BGMarray[2];
        speaker_B.Play();
    }
    public void BG_AmdientSound3()
    {
        speaker_A.clip = BGMarray[3];
        speaker_A.volume = 0.8f;
        speaker_A.Play();
    }

    public void TH1CubeDrop2()
    {
        speaker_D.clip = TH1CubeDrop2Sound;
        speaker_D.Play();
    }

    public void PlayBackgroundMusic(int level)
    {
        AudioClip clipToPlay = null;
        switch (level)
        {
            case 1: clipToPlay = BGMarray[0]; break;
            case 2: clipToPlay = BGMarray[1]; break;
            case 3: clipToPlay = BGMarray[2]; break;
            case 4: clipToPlay = BGMarray[3]; break;
                // ... (다른 레벨의 음악)
        }

        if (clipToPlay != null)
        {

            PlaySound(clipToPlay, speaker_BGM);  // 배경음악이 재생될 AudioSource 선택
        }
    }
}


