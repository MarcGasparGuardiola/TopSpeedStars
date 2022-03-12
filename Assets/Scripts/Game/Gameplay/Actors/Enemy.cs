using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float torque = 500f;
    public float smoothTime = 0.3F;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    public List<Transform> waypoints;
    Transform currentTarget;
    private int _index = 0;


    [Header("Physics")]
    [Tooltip("Max velocity")] public float maxVelocity = 1000f;
    [Tooltip("Force to push plane forwards with")] public float thrust = 1000f;
    [Tooltip("Force to push plane forwards with")] public float maxThrust = 1000f;
    private float actualThrust = 0;
    [Tooltip("Acceleration of aircraft")] public float acceleration = 100f;
    [Tooltip("Drag of aircraft")] public float dragRate = 30f;
    [Tooltip("Pitch, Yaw, Roll")] public Vector3 turnTorque = new Vector3(90f, 25f, 45f);
    [Tooltip("Multiplier for all forces")] public float forceMult = 1000f;
    [Tooltip("Inertia tensors (x, y ,z)")] public Vector3 tensor = new Vector3(2000f, 2300f, 352f);

    [Header("Autopilot")]
    [Tooltip("Sensitivity for autopilot flight.")] public float sensitivity = 5f;
    [Tooltip("Angle at which airplane banks fully into target.")] public float aggressiveTurnAngle = 10f;

    [Header("Input")]
    [SerializeField] [Range(-1f, 1f)] private float pitch = 0f;
    [SerializeField] [Range(-1f, 1f)] private float yaw = 0f;
    [SerializeField] [Range(-1f, 1f)] private float roll = 0f;

    public float Pitch { set { pitch = Mathf.Clamp(value, -1f, 1f); } get { return pitch; } }
    public float Yaw { set { yaw = Mathf.Clamp(value, -1f, 1f); } get { return yaw; } }
    public float Roll { set { roll = Mathf.Clamp(value, -1f, 1f); } get { return roll; } }

    private Rigidbody rigid;

    private bool rollOverride = false;
    private bool pitchOverride = false;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Count > 0 && waypoints[0] != null)
        {
            currentTarget = waypoints[_index];
        }
        else {
            Debug.LogError("Posa la llista de waypoints");
        }
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Calculate the autopilot stick inputs.
        float autoYaw = 0f;
        float autoPitch = 0f;
        float autoRoll = 0f;
   
        RunAutopilot(waypoints[_index].position, out autoYaw, out autoPitch, out autoRoll);

        // Use either keyboard or autopilot input.
        yaw = autoYaw;
        pitch = autoPitch;
        roll = autoRoll;
        try
        {
            var distance = Vector3.Distance(rb.position, waypoints[_index].position);
            if (distance < 100 && waypoints.Count-1 > _index) {
                _index++;
            }
        } catch { }
       
    }

    private void RunAutopilot(Vector3 flyTarget, out float yaw, out float pitch, out float roll)
    {
        // This is my usual trick of converting the fly to position to local space.
        // You can derive a lot of information from where the target is relative to self.
        var localFlyTarget = transform.InverseTransformPoint(flyTarget).normalized * sensitivity;
        var angleOffTarget = Vector3.Angle(transform.forward, flyTarget - transform.position);

        var percentOfAngle = angleOffTarget / 360;
        // Debug.Log(percentOfAngle);
        var percentOfThrust = thrust * 1/percentOfAngle;

        actualThrust = Mathf.Clamp(percentOfThrust, maxThrust / 90, maxThrust);
        // IMPORTANT!
        // These inputs are created proportionally. This means it can be prone to
        // overshooting. The physics in this example are tweaked so that it's not a big
        // issue, but in something with different or more realistic physics this might
        // not be the case. Use of a PID controller for each axis is highly recommended.

        // ====================
        // PITCH AND YAW
        // ====================

        // Yaw/Pitch into the target so as to put it directly in front of the aircraft.
        // A target is directly in front the aircraft if the relative X and Y are both
        // zero. Note this does not handle for the case where the target is directly behind.
        yaw = Mathf.Clamp(localFlyTarget.x, -1f, 1f);
        pitch = -Mathf.Clamp(localFlyTarget.y, -1f, 1f);

        // ====================
        // ROLL
        // ====================

        // Roll is a little special because there are two different roll commands depending
        // on the situation. When the target is off axis, then the plane should roll into it.
        // When the target is directly in front, the plane should fly wings level.

        // An "aggressive roll" is input such that the aircraft rolls into the target so
        // that pitching up (handled above) will put the nose onto the target. This is
        // done by rolling such that the X component of the target's position is zeroed.
        var agressiveRoll = Mathf.Clamp(localFlyTarget.x, -1f, 1f);

        // A "wings level roll" is a roll commands the aircraft to fly wings level.
        // This can be done by zeroing out the Y component of the aircraft's right.
        var wingsLevelRoll = transform.right.y;

        // Blend between auto level and banking into the target.
        var wingsLevelInfluence = Mathf.InverseLerp(0f, aggressiveTurnAngle, angleOffTarget);
        roll = Mathf.Lerp(wingsLevelRoll, agressiveRoll, wingsLevelInfluence);
    }


    private void FixedUpdate()
    {

        //actualThrust = 75;
        // Debug.Log(actualThrust);

        // Ultra simple flight where the plane just gets pushed forward and manipulated
        // with torques to turn.
        rb.AddRelativeForce(Vector3.forward * actualThrust * forceMult, ForceMode.Force);

        rb.AddRelativeTorque(new Vector3(turnTorque.x * pitch,
                                            turnTorque.y * yaw,
                                            -turnTorque.z * roll) * forceMult,
                                ForceMode.Force);

       // Debug.Log(rb.velocity);
    }
}
