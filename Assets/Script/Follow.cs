using UnityEngine;

public class Follow : MonoBehaviour
{
   RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(GameManager.Instance.player.transform.position);
            
    }
}
