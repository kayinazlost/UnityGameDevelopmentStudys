using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武装のマウントシステム
/// 一般的には武器を装備させる場所を管理し、且つ火器管制システム(FireControlSystem)との
/// パイプラインとしての機能を持つ
/// </summary>
public class Mount001 : MonoBehaviour
{
    [Header("武器装備位置")]
    public List<Transform> m_MountPoint;
}
