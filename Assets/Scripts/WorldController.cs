using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    [SerializeField] Vector3 DragStartPos;
    [SerializeField] float Multiplier;
    [SerializeField] float Magnitude;
    [SerializeField] float Mx;
    [SerializeField] float m_Time;
    [SerializeField] float diff;
    [SerializeField] bool Mag;
    private float previousMagnitude;
    private int unchangedCounter = 0;
    private int constantThreshold = 60;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) DragStartPos = Input.mousePosition;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 CurrentPos = Input.mousePosition;
            Vector3 Distance = DragStartPos - CurrentPos;
            Magnitude = Distance.normalized.x >= 0 ? Distance.normalized.x : Magnitude;
            Magnitude = CheckIfMagnitudeConstant(Distance.normalized.x) ? 0 : Magnitude;
            if(CheckIfMagnitudeConstant(Distance.normalized.x))
            {
                float TempMag = Magnitude;
                
            }
            m_animator.SetFloat("Walking", Magnitude);
        }
        if(!Input.GetMouseButton(0))
        {
            GetMagnitudeToNormal(0);
        }
        
    }

    private void GetMagnitudeToNormal(float target)
    {
        Magnitude = Mathf.MoveTowards(Magnitude, target, Time.deltaTime / m_Time);
        m_animator.SetFloat("Walking", Magnitude);
    }

    private bool CheckIfMagnitudeConstant(float p_mag)
    {
        if (Mathf.Approximately(p_mag, previousMagnitude))
        {
            unchangedCounter++;
        }
        else
        {
            unchangedCounter = 0;
        }

        if (unchangedCounter > constantThreshold)
        {
            previousMagnitude = p_mag;
            return true;
            
        }

        previousMagnitude = p_mag;
        return false;

    }

}
