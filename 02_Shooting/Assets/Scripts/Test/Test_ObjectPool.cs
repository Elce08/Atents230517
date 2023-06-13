using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ObjectPool : TestBase
{
    public PoolObjectType objType;
    
    List<GameObject> objects = new List<GameObject>();

    protected override void Test1(InputAction.CallbackContext context)
    {
        GameObject test = Factory.Inst.GetObject(objType);
        test.transform.position = transform.position;
        objects.Add(test);
    }

    protected override void Test2(InputAction.CallbackContext context)
    {
        while(objects.Count > 0)
        {
            GameObject del = objects[0];
            objects.RemoveAt(0);
            del.gameObject.SetActive(false);
        }
        objects.Clear();
    }

    protected override void Test3(InputAction.CallbackContext context)
    {
        EnemyCurve curve = Factory.Inst.GetEnemyCurve(transform.position);
        objects.Add(curve.gameObject);
    }
}
