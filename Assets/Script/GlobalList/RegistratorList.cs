using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ���������� ���� ������ ��������
/// </summary>
public abstract class RegistratorGo : MonoBehaviour
{
    private readonly static List<RegistratorConstruction> DataGO = new List<RegistratorConstruction>();
    /// <summary>
    /// ������� � ����
    /// </summary>
    /// <param name="registrator"></param>
    public void SetData(RegistratorConstruction registrator)
    {
        DataGO.Add(registrator);
    }
    /// <summary>
    /// ������� ����
    /// </summary>
    /// <returns></returns>
    public List<RegistratorConstruction> GetData()
    {
        return DataGO;
    }
}
