using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
    private Healt _char;

    //tresh
    //// A Test behaves as an ordinary method
    //[Test]
    //public void NewTestScriptSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //// `yield return null;` to skip a frame.

    [SetUp]//��� ���� �� ��������� ����� ������� ��������� ������������������� ��������
    public void TestSetup()
    {
        StartTestMetod();
    }

    [UnityTest]//������ ������ ������
    public IEnumerator A_PlayerTest()
    {
        yield return new WaitForSeconds(5);
        FindObjectPlayer();
        PosTestMetod();

        //yield return null;
        //Assert.AreEqual(true,true);//�������� ��� true ����� true
    }

    private void StartTestMetod()
    {
        SceneManager.LoadScene(0);//�������� �����

    }

    private void FindObjectPlayer()
    {
        _char = GameObject.FindObjectOfType<Healt>();//������ ������ �� ��������
    }

    private void PosTestMetod()
    {
        UnityEngine.Assertions.Assert.IsNotNull(_char);
    }

    [UnityTest]//������ ������ ������
    public IEnumerator B_HealtPlayerTest()
    {

        if (_char == null)
        {
            yield return null;
        }

        _char.HealtCount = 0;
        yield return new WaitForSeconds(1);
        UnityEngine.Assertions.Assert.IsNull(_char);//������ ������ ���� �����
    }
}

//���� ������������ ������
//��������� �������� � Unit-�������.



//��� ����� �������
//�������� � ������ Test Framework.
//�������� ��� ���� ���� ������ Unit-������, ������� ������ ��������� ������ ������ ����.


//������ � ������������
//���������� ��������� ����� �� ������ ������� � ������������ � ���, ��� ��� ���������.



//��� �����������
//������� Unit-������ � ������� � �� ������������.



//��� ��������� ������ �� ��������
//�������� ����� ������� Unity ����� ����� ����.
