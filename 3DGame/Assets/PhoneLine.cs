using Unity.VisualScripting;
using UnityEngine;

public class PhoneLine : MonoBehaviour
{
    public Transform TargetLine;
    public float PhoneLineDrip = 0.1f;
    public Transform[] Spokes;
    public Transform[] TargetSpokes;
    void Start()
    {
        Transform MySpokes = transform.Find("Spokes");
        Spokes[0] = MySpokes.Find("Spoke1");
        Spokes[1] = MySpokes.Find("Spoke2");
        Spokes[2] = MySpokes.Find("Spoke3");
        Spokes[3] = MySpokes.Find("Spoke4");
        for (int i = 0; i < 4; i++)
        {
            Spokes[i].GetComponent<LineRenderer>().SetPosition(0, Spokes[i].position);
            Spokes[i].GetComponent<LineRenderer>().SetPosition(1, Spokes[i].position);
            Spokes[i].GetComponent<LineRenderer>().SetPosition(2, Spokes[i].position);
        }
        if (TargetLine == null) { return; }
        Transform Spokes1 = TargetLine.Find("Spokes");
        TargetSpokes[0] = Spokes1.Find("Spoke1");
        TargetSpokes[1] = Spokes1.Find("Spoke2");
        TargetSpokes[2] = Spokes1.Find("Spoke3");
        TargetSpokes[3] = Spokes1.Find("Spoke4");

        for (int i = 0; i < 4; i++)
        {
            Vector3 AveragePosition = Spokes[i].position + TargetSpokes[i].position;
            AveragePosition /= 2;
            Spokes[i].GetComponent<LineRenderer>().SetPosition(1, AveragePosition + (Vector3.down * PhoneLineDrip));
            Spokes[i].GetComponent<LineRenderer>().SetPosition(2, TargetSpokes[i].position);
        }
    }
}
