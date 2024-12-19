using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformManager : MonoBehaviour
{
    public GameObject[] platforms; // ÇÃ·§Æû ¹è¿­
    private int realPlatformIndex; // ÁøÂ¥ ÇÃ·§Æû ÀÎµ¦½º

    void Start()
    {
        // ÇÃ·§Æû Áß ÇÏ³ª ÁøÂ¥ ÇÃ·§ÆûÀ¸·Î ·£´ý ¼±ÅÃ
        realPlatformIndex = Random.Range(0, platforms.Length);

        // ÇÃ·§Æû ¼³Á¤
        for (int i = 0; i < platforms.Length; i++)
        {
            if (i == realPlatformIndex)
            {
                platforms[i].GetComponent<FakePlatform>().SetAsReal(); // ÁøÂ¥ ÇÃ·§Æû ¼³Á¤
            }
            else
            {
                platforms[i].GetComponent<FakePlatform>().SetAsFake(); // °¡Â¥ ÇÃ·§Æû ¼³Á¤
            }
        }
    }
}
