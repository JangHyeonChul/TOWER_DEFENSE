using UnityEngine;

public class CommonUtils
{

    // GameObject�� Tag�� ���ϰ��
    public static bool IsEnemy(GameObject gameObject)
    {
        return gameObject.CompareTag("Enemy");

    }
}
