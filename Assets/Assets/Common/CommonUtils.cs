using UnityEngine;

public class CommonUtils
{

    // GameObject의 Tag가 적일경우
    public static bool IsEnemy(GameObject gameObject)
    {
        return gameObject.CompareTag("Enemy");

    }
}
