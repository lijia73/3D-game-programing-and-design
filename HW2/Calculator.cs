using UnityEngine;
using System.Collections;

public class Calculator : MonoBehaviour
{

    //用来显示结果
    public string stroutcome = "0";
    public string procedure = "";
    //操作数
    public static string stra;
    public static string strb;
    //标记符号
    public static string str0pt;
    //计算结果
    float sum = 0;

    void OnGUI()
    {
        //对数字进行处理
        if (GUI.Button(new Rect(100, 100, 50, 30), "1"))
        {
            stra += "1";
            stroutcome = stra;
            procedure += "1";
        }
        if (GUI.Button(new Rect(160, 100, 50, 30), "2"))
        {
            stra += "2";
            stroutcome = stra;
            procedure += "2";
        }
        if (GUI.Button(new Rect(220, 100, 50, 30), "3"))
        {
            stra += "3";
            stroutcome = stra;
            procedure += "3";
        }
        if (GUI.Button(new Rect(280, 100, 50, 30), "4"))
        {
            stra += "4";
            stroutcome = stra;
            procedure += "4";
        }
        if (GUI.Button(new Rect(100, 140, 50, 30), "5"))
        {
            stra += "5";
            stroutcome = stra;
            procedure += "5";
        }
        if (GUI.Button(new Rect(160, 140, 50, 30), "6"))
        {
            stra += "6";
            stroutcome = stra;
            procedure += "6";
        }
        if (GUI.Button(new Rect(220, 140, 50, 30), "7"))
        {
            stra += "7";
            stroutcome = stra;
            procedure += "7";
        }
        if (GUI.Button(new Rect(280, 140, 50, 30), "8"))
        {
            stra += "8";
            stroutcome = stra;
            procedure += "8";
        }
        if (GUI.Button(new Rect(100, 180, 50, 30), "9"))
        {
            stra += "9";
            stroutcome = stra;
            procedure += "9";
        }
        if (GUI.Button(new Rect(160, 180, 50, 30), "0"))
        {
            stra += "0";
            stroutcome = stra;
            procedure += "0";
        }
        //计算符号
        if (GUI.Button(new Rect(220, 180, 50, 30), "+"))
        {
            str0pt = "+";
            print(strb);
            if (stra != null)
            {
                strb = stra;
            }
            stra = "";
            stroutcome = strb;
            procedure += str0pt;
        }
        if (GUI.Button(new Rect(280, 180, 50, 30), "/"))
        {
            str0pt = "/";
            if (stra != null)
            {
                strb = stra;
            }
            stra = "";
            stroutcome = strb;
            procedure += str0pt;
        }
        if (GUI.Button(new Rect(100, 220, 50, 30), "*"))
        {
            str0pt = "*";
            if (stra != null)
            {
                strb = stra;
            }
            stra = "";
            stroutcome = strb;
            procedure += str0pt;
        }
        if (GUI.Button(new Rect(160, 220, 50, 30), "-"))
        {
            str0pt = "-";
            if (stra != null)
            {
                strb = stra;
            }
            stra = "";
            stroutcome = strb;
            procedure +=str0pt;
        }
        if (GUI.Button(new Rect(100, 260, 50, 30), "C"))
        {
            if (stra == "")
            {
                stroutcome = "0";
                return;
            }
            else
            {
                stra = stra.Substring(0, stra.Length - 1);
            }
            stroutcome = stra;
            if(procedure.Length>0)
            procedure = procedure.Substring(0, procedure.Length - 1);
        }
        if (GUI.Button(new Rect(220, 220, 50, 30), "."))
        {
            stra += ".";
            stroutcome = stra;
            procedure += ".";
        }
            if (GUI.Button(new Rect(280, 220, 50, 30), "="))
        {
            if (str0pt == "+")
            {
                sum = float.Parse(stra) + float.Parse(strb);
            }
            else if (str0pt == "-")
            {
                sum = float.Parse(strb) - float.Parse(stra);
            }
            else if (str0pt == "*")
            {
                sum = float.Parse(strb) * float.Parse(stra);
            }
            else if (str0pt == "/")
            {
                sum = float.Parse(strb) / float.Parse(stra);
            }

            strb ="";
            stra = sum.ToString();
            stroutcome = stra;
            procedure = stra;
        }
        if (GUI.Button(new Rect(160, 260, 50, 30), "CE"))
        {
            stra = "";
            strb = "";
            sum = 0;
            stroutcome = "";
            procedure = "";
        }
        GUI.skin.GetStyle("Label").fontSize = 20;
        GUI.Label(new Rect(100, 50, 100, 30), stroutcome);
        GUI.skin.GetStyle("Label").fontSize = 12;
        GUI.Label(new Rect(200, 70, 100, 30), procedure);

    }
}

