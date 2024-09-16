using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/*
 using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] LayerMask tongueLayer;
    [SerializeField] LayerMask frogBodyLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask waterLayer;

    // 먹었을 때 채워지는 HP양
    [SerializeField] int deltaHp = 5;
    
    // 먹었을 때 증가하는 점수
    [SerializeField] int deltaScore = 1;
    
    // 먹었을 때 변경되는 외형
    [SerializeField] CharacterPreset preset;



void OnTriggerEnter2D(Collider2D col)
{
    if ((tongueLayer.value & (1 << col.gameObject.layer)) != 0)
    {
        if (Frog.Instance.CanCatch)
        {
            Frog.Instance.AttachItemToTongue(this);
        }
    }
    else if ((frogBodyLayer.value & (1 << col.gameObject.layer)) != 0)
    {
        if (Frog.Instance.IsAttachedToTongue(this) || Frog.Instance.CanCatch)
        {
            Frog.Instance.Score += deltaScore;
            Frog.Instance.Hp += deltaHp;
            if (deltaHp < 0)
            {
                Frog.Instance.PlayDamageClip();
            }
            else
            {
                Frog.Instance.PlayScoreClip();
            }

            Destroy(gameObject);

            // 외형 변경!!!
            if (preset != null)
            {
                Frog.Instance.Preset = preset;
            }
        }
    }
    else if ((groundLayer.value & (1 << col.gameObject.layer)) != 0)
    {
        // 아무것도 하지 않는다.
    }
    else if ((waterLayer.value & (1 << col.gameObject.layer)) != 0)
    {
        // 아무것도 하지 않는다.
    }
    else
    {
        Debug.LogError("Unknown collision layer");
    }
}
}*/