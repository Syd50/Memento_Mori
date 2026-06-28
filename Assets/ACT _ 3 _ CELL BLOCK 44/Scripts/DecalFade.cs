using UnityEngine;
using UnityEngine.Rendering.Universal; //URP renderer

public class DecalFade : MonoBehaviour
{

    public float fadeDuration = 0.3f;

    private DecalProjector projector;
    private Material materialInstance;

    private float alpha = 0f;
    private bool fading = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TriggerFade();
        projector = GetComponent<DecalProjector>();

        materialInstance = projector.material;

        SetOpacity(0f);
    }

    public void TriggerFade()
    {
        fading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fading) return;

        alpha += Time.deltaTime / fadeDuration;
        alpha = Mathf.Clamp01(alpha);

        if (alpha >= 1f)
            fading = false;
    }

    void SetOpacity(float value)
    {
        materialInstance.SetFloat("_Opacity", value);
    }

}

//need to reference back to this where player is controlled