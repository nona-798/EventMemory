using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("배경의 스크롤 속도 값")]
    public float scrollSpeed;

    [Header("References")]
    [Tooltip("참조해야 할 메쉬 렌더러를 적용")]
    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundScroll();
    }
    private void BackGroundScroll()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() / 20 * Time.deltaTime, 0);
    }
}
