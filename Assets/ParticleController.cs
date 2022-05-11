using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem particle1, particle2;
    [SerializeField] RectTransform rect, rect2;

    private void Start()
    {
        particle1.gameObject.SetActive(true);
        
        particle2.gameObject.SetActive(false);
        
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        particle1.scalingMode = ParticleSystemScalingMode.Local;
        particle2.scalingMode = ParticleSystemScalingMode.Local;
        if (Input.GetMouseButtonDown(0))
        {
            MoveingObj();
        }
    }

    void MoveingObj()
    {
        particle1.gameObject.SetActive(false);
        Scaling(rect.gameObject, 0.266f, 0.266f, 0.266f, 1f);
        LeanTween.rotateZ(rect.gameObject, 1080f, 3f);
        LeanTween.move(rect, new Vector2(227.7f, 153.2f), 1f); 
        LeanTween.move(rect2, new Vector2(-293.5f, 153.5f), 1f);
        particle2.gameObject.SetActive(true);
            
    }

    public void Scaling(GameObject obj, float xScale, float yScale, float zScale, float time)
    {
        Vector3 scale = obj.transform.localScale;
        LeanTween.value(obj, scale, new Vector3(xScale, yScale, zScale), time).setOnUpdate((Vector3 _value) => {
            scale = _value;
            obj.transform.localScale = scale;
        }).setEase(LeanTweenType.easeOutElastic);
    }
}
