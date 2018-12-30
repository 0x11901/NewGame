using UnityEngine;

public class Initialization : MonoBehaviour
{
    #region Unity

    #endregion

    #region Tools

    private Vector3 GetObjectSize(GameObject go)
    {
        var realSize = Vector3.zero;

        var mesh = go.GetComponent<MeshFilter>().sharedMesh;
        if (mesh == null)
        {
            return realSize;
        }

        var meshSize = mesh.bounds.size;
        var scale = transform.lossyScale;
        realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);

        return realSize;
    }

    #endregion
}