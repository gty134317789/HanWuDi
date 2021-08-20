using UnityEngine;

public class CombineMeshes : MonoBehaviour
{

    private void Start()
    {
        MergeMesh();
    }


    private void MergeMesh()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();   //获取所有子物体的网格
        CombineInstance[] combineInstances = new CombineInstance[meshFilters.Length]; //新建一个合并组，长度与 meshfilters一致
        for (int i = 0; i < meshFilters.Length; i++)                                  //遍历
        {
            combineInstances[i].mesh = meshFilters[i].sharedMesh;                   //将共享mesh，赋值
            combineInstances[i].transform = transform.worldToLocalMatrix * meshFilters[i].transform.localToWorldMatrix; //本地坐标转矩阵，赋值
        }
        Mesh newMesh = new Mesh();                                  //声明一个新网格对象
        newMesh.CombineMeshes(combineInstances);                    //将combineInstances数组传入函数
        gameObject.AddComponent<MeshFilter>().sharedMesh = newMesh; //给当前空物体，添加网格组件；将合并后的网格，给到自身网格
                                                                    //到这里，新模型的网格就已经生成了。运行模式下，可以点击物体的 MeshFilter 进行查看网格
        gameObject.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/IronBall"); //给当前空物体添加渲染组件，给新模型网格上色;
        foreach (Transform t in transform)                                                              //禁用掉所有子物体
        {
            t.gameObject.SetActive(false);
        }
    }
}