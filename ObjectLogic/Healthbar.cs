using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Entity connectedEntity;
    [SerializeField] private Transform foreground;
    [SerializeField] private Transform background;
    [SerializeField] private Text text;

    public bool disappearOnMaxHealth = true;

    private void Update()
    {
        float scale = (float)connectedEntity.currentHealth / (float)connectedEntity.maxHealth;
        foreground.localScale = new Vector3 (Mathf.Clamp(scale, 0f, 1f), foreground.localScale.y, foreground.localScale.z);
        background.localScale = Vector3.Lerp(background.localScale, new Vector3(Mathf.Clamp(scale, 0f, 1f), foreground.localScale.y, foreground.localScale.z), Time.deltaTime * 3f);

        if(text != null )
        {
            text.text = $"{connectedEntity.currentHealth} / {connectedEntity.maxHealth}";
        }

        if(connectedEntity.currentHealth >= connectedEntity.maxHealth && disappearOnMaxHealth == true)
        {
            foreground.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
        }else
        {
            foreground.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
        }
    }
}
