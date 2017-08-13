using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CommonHelper
{
    /// <summary>
    /// �Զ��ŷָ��Ĺ淶�ַ���ת��Vector2;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Vector2 StrToVector2(string str)
    {
        Vector2 value = Vector2.zero;
        string[] strArray = str.Split(',');
        if (strArray.Length < 2)
        {
            Debug.LogError(str + " string to Vector2 failed with , spilt");
            return value;
        }
        float x = Convert.ToSingle(strArray[0]);
        float y = Convert.ToSingle(strArray[1]);
        value = new Vector2(x, y);

        return value;
    }

    /// <summary>
    /// �Զ��ŷָ��Ĺ淶�ַ���ת��Vector2;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Vector3 StrToVector3(string str)
    {
        if (string.IsNullOrEmpty(str))
            return Vector3.zero;

        Vector3 value = Vector3.zero;
        string[] strArray = str.Split(',');
        if (strArray.Length < 3)
        {
            Debug.LogError(str + " string to Vector2 failed with , spilt");
            return value;
        }
        float x = Convert.ToSingle(strArray[0]);
        float y = Convert.ToSingle(strArray[1]);
        float z = Convert.ToSingle(strArray[2]);
        value = new Vector3(x, y, z);

        return value;
    }

    /// <summary>
    /// ��Vector3ת�����ַ���;
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static string Vector3ToStr(Vector3 vec)
    {
        return vec.x + "," + vec.y + "," + vec.z;
    }

    /// <summary>
    /// ��Vector2ת�����ַ���;
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static string Vector2ToStr(Vector2 vec)
    {
        return vec.x + "," + vec.y;
    }

    /// <summary>
    /// ��Vector3���屣����λС��;
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="decimals">С��λ��</param>
    /// <returns></returns>
    public static Vector3 Vector3ToRound(Vector3 vec, int decimals)
    {
        float x = (float)Math.Round(vec.x, decimals);
        float y = (float)Math.Round(vec.y, decimals);
        float z = (float)Math.Round(vec.z, decimals);
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// ��Vector2���屣����λС��
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="decimals">С��λ��</param>
    /// <returns></returns>
    public static Vector2 Vector2ToRound(Vector2 vec, int decimals)
    {
        float x = (float)Math.Round(vec.x, decimals);
        float y = (float)Math.Round(vec.y, decimals);
        return new Vector2(x, y);
    }

    /// <summary>
    /// ���ݸ��ʻ�ȡ������Ƿ������;
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool OnProbability(float value)
    {
        if (value >= 1)
            return true;

        if (value <= 0)
            return false;

        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng =
            new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        int seed = BitConverter.ToInt32(bytes, 0);

        System.Random random = new System.Random(seed);
        int randomValue = random.Next(100);
        if (randomValue < value * 100)
        {
            return true;
        }

        return false;
    }

    public static bool IsGetValue(int baseValue)
    {
        if (baseValue <= 0)
            return false;

        if (baseValue >= 100)
            return true;

        int rnd = UnityEngine.Random.Range(0, 100);

        return rnd <= baseValue;
    }

    /// <summary>
    /// ��ȡƷ����ɫ;
    /// </summary>
    /// <param name="heroQuailty">0ʱΪ��   1ʱΪ��   2ʱΪ�� 	3ʱΪ��   4ʱΪ��</param>
    /// <returns></returns>
    public static Color GetSummonerQualityColor(int heroQuailty)
    {
        Color color = Color.white;
        switch (heroQuailty)
        {
            case 0:
                color = Color.white;
                break;
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.blue;
                break;
            case 3:
                color = new Color(191f / 255f, 79f / 255f, 249f / 255f, 1f);
                break;
            case 4:
                color = new Color(255f / 255f, 139f / 255f, 36f / 255f, 1f);
                break;
        }
        return color;
    }

    /// <summary>
    /// ����������ȡʱ���ַ���;
    /// </summary>
    /// <param name="second"></param>
    /// <returns></returns>
    public static string GetTimeStr(int second)
    {
        int minute = second / 60;
        int sec = second % 60;
        string timeStr = "";
        if (minute <= 9)
        {
            timeStr = "0" + minute + ":";
        }
        else
        {
            timeStr = minute + ":";
        }

        if (sec <= 9)
        {
            timeStr += "0" + sec;
        }
        else
        {
            timeStr += sec + "";
        }

        return timeStr;
    }

    /// <summary>
    /// ����Ψһ��ʶID;
    /// </summary>
    /// <returns></returns>
    public static int GetUniqueID(GameObject unit)
    {
        if (unit == null)
        {
            Debug.Log("unit is invalid");
            return 0;
        }

        return unit.GetInstanceID();
    }

    /// <summary>
    /// �ַ���ת����;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int Str2Int(string str)
    {
        return string.IsNullOrEmpty(str) == true ? 0 : Convert.ToInt32(str);
    }

	public static Int64 Str2Int64(string str)
	{
		return string.IsNullOrEmpty(str) == true ? 0 : Convert.ToInt64(str);
	}
    /// <summary>
    /// �ַ���ת������;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int[] Str2IntArray(string str)
    {
		if( str == "" )
		{
			return new int[0];
		}
        int temp = -1;
		string[] strArray = str.Split(';');
        int[] intArray = new int[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            temp = Str2Int(strArray[i]);
            intArray[i] = temp;
        }

        return intArray;
    }

    /// <summary>
    /// ����ת���ַ���;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Array2Str(int[] arr)
    {
        string temp = "";
		if( arr.Length > 0 )
		{
			temp = arr[0].ToString();
		}

        for (int i = 1; i < arr.Length; i++)
        {
			temp += ";";
			temp += arr[i].ToString();
        }

        return temp;
    }
    public static string Array2Str(string[] arr)
    {
        string temp = "";
		if( arr.Length > 0 )
		{
			temp = arr[0].ToString();
		}

        for (int i = 1; i < arr.Length; i++)
        {
			temp += ";";
			temp += arr[i].ToString();
        }

        return temp;
    }


	public static List<int> Str2IntList(string str)
	{
		int temp = -1;
		string[] strArray = str.Split(';');
		List<int> intList = new List<int>();
		for (int i = 0; i < strArray.Length; i++)
		{
			temp = Str2Int(strArray[i]);
			intList.Add(temp);
		}
		
		return intList;
	}

	/// <summary>
	/// �ַ���ת������;
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	public static string[] Str2StringArray(string str)
	{
		string[] strArray = str.Split(';');
		return strArray;
	}

    /// <summary>
    /// �ַ���ת��bool;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool Str2Boolean(string str)
    {
        if (str == "1" || str.ToLower() == "true" || str.ToLower() == "yes")
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �ַ���ת��float;
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static float Str2Float(string str)
    {
        return string.IsNullOrEmpty(str) == true ? 0 : Convert.ToSingle(str);
    }

    /// <summary>
    /// ͨ���ı����Ѱ�ұ����ı�
    /// </summary>
    /// <param string="ID"></param>
    /// <returns></returns>
    //public static string IdToString(string ID)
    //{
    //    LocalTextManager textManager = DataManager.s_LocalText;
 
    //    LocalText text = textManager.GetData(ID);
    //    if (text == null)
    //    {
    //        return ID;
    //    }

    //    if (string.IsNullOrEmpty(text.Text))
    //    {
    //        return ID;
    //    }

    //    return (text.Text).Trim();
    //}

    /// <summary>
    /// ת��4λС������;
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static float ToFloat4(float number)
    {
        int int4 = ToInt4(number);
        return ToFloat4(int4);
    }

    /// <summary>
    /// ת������;
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static float ToFloat4(int number)
    {
        return number / 10000.0f;
    }

    /// <summary>
    /// ת��4λ����;
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int ToInt4(float number)
    {
        return (int)(number * 10000);
    }

    /// <summary>
    /// ��ɫת��;
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Color GetColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

    /// <summary>
    /// ����ָ������������߶Ȼ�ȡʩ����;
    /// </summary>
    /// <param name="x">����</param>
    /// <param name="y">�߶�</param>
    /// <returns></returns>
    public static Vector3 GetForce(float x, float y)
    {
        float angle = Mathf.Atan(4 * y / x);
        float force = Mathf.Sqrt(2 * -Physics.gravity.y * y) / Mathf.Sin(angle);
        Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized;

        return force * dir;
    }

    /// <summary>
    /// ����ָ���߶Ȼ�ȡ����߶�����Ҫ��ʱ�䣨б���˶�������ߵ����õ�ʱ�䣩
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public static float GetTimeInTop(float y)
    {
        float flyTime = Mathf.Sqrt(2 * -Physics.gravity.y * y) / -Physics.gravity.y;
        return flyTime;
    }

    /// <summary>
    /// ���ݺ�������ȡ���������;
    /// </summary>
    /// <param name="x">����</param>
    /// <returns></returns>
    public static float GetMaxPower(float x)
    {
        float force = Mathf.Sqrt(-Physics.gravity.y * x / 2.0f) / Mathf.Sin(Mathf.PI / 4);
        return force;
    }

    /// <summary>
    /// ת��Ǯ��ȡ������
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int ToDing(long money)
    {
        return (int)(money / 1000000);
    }
    /// <summary>
    /// ת��Ǯ��ȡ������
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public static int ToLiang(long money)
    {
        int liang = (int)(money / 1000);
        return liang % 1000;
    }
    /// <summary>
    /// ת��Ǯ��ȡ���ġ�
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public static int ToWen(long money)
    {
        return (int)(money % 1000);
    }

	/// <summary>
	/// ?????;
	/// </summary>
	/// <param name="????"></param>
	/// <returns></returns>
	public static object RandomObject(List<object> list)
	{
		if (list == null)
		{
			return null;
		}
		
		if (list.Count <= 0)
		{
			return null;
		}

		System.Random rnd = new System.Random();
		int result = rnd.Next(0, list.Count);
		
		return list[result];
	}
}