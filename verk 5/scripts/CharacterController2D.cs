using UnityEngine;  // Notkunin af Unity engine, sem gerir okkur kleift að vinna með leikfang og leikjasöfn
using UnityEngine.Events;  // Eining sem gerir okkur kleift að senda og hlusta á viðburði í Unity umhverfinu

public class CharacterController2D : MonoBehaviour  // Klasinn sem stýrir hreyfingu og stöðu karaktera
{
    [SerializeField] private float m_JumpForce = 400f;  // Styrkur hoppa.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Hraði á crouch hreyfingu (0-1).
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // Stærð smyrslar við hreyfingu.
    [SerializeField] private bool m_AirControl = false;  // Hvort hægt er að stjórna hreyfingu þegar hoppað er.
    [SerializeField] private LayerMask m_WhatIsGround;  // Lag sem skilgreinir hvað telst vera jörð fyrir karakterinn.
    [SerializeField] private Transform m_GroundCheck;  // Staðsetning til að athuga hvort karakterinn sé á jörðinni.
    [SerializeField] private Transform m_CeilingCheck;  // Staðsetning til að athuga hvort karakterinn sé neðst í lofti.
    [SerializeField] private Collider2D m_CrouchDisableCollider;  // Kassi sem á að vera óvirkur þegar karakterinn er í crouch stöðu.

    const float k_GroundedRadius = .2f;  // Fasti sem skilgreinir radíus hrings sem notaður er til að ákveða hvort karakterinn sé á jörðinni.
    private bool m_Grounded;  // Hvort karakterinn sé á jörðinni eða ekki.
    const float k_CeilingRadius = .2f;  // Fasti sem skilgreinir radíus hrings sem notaður er til að ákveða hvort karakterinn geti stóðst upp.
    private Rigidbody2D m_Rigidbody2D;  // Rigidbody2D hlutur karakterins.
    private bool m_FacingRight = true;  // Hvort karakterinn sé að horfa til hægri eða vinstri.
    private Vector3 m_Velocity = Vector3.zero;  // Hreyfingarkraftur.

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;  // Viðburður sem kallast þegar karakterinn lendir á jörðinni.

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;  // Viðburður sem kallast þegar karakterinn byrjar að croucha.
    private bool m_wasCrouching = false;  // Hvort karakterinn hafi verið að croucha áður en núna.

    private void Awake()
	{
		        m_Rigidbody2D = GetComponent<Rigidbody2D>();  // Sækjum Rigidbody2D komponentið sem er tengt þessum GameObject.

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();  // Ef OnLandEvent er ekki tilgreint, búum við til nýjan UnityEvent.

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();  // Ef OnCrouchEvent er ekki tilgreint, búum við til nýjan BoolEvent.

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;  // Geymum gildið á m_Grounded á undan uppfærslunni.
        m_Grounded = false;  // Setjum m_Grounded í false áður en við athugum hvort karakterinn sé á jörðinni.

        // Karakterinn er á jörðinni ef hringur sem er sent niður á m_GroundCheck staðsetninguna sker eitthvað sem er merkt sem jörð.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;  // Karakterinn er á jörðinni.
                if (!wasGrounded)
                    OnLandEvent.Invoke();  // Kallar á viðburðinn OnLandEvent ef karakterinn var ekki á jörðinni á undan.
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;  // Ef karakterinn er að reyna að stóða upp en það er loft yfir, þá heldum við honum í crouch stöðu.
            }
        }

        if (m_Grounded || m_AirControl)  // Ef karakterinn er á jörðinni eða airControl er virkt, þá stjórnarum við hreyfingu.
        {
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);  // Kallar á viðburðinn OnCrouchEvent með gildinu true ef karakterinn byrjar að croucha.
                }

                move *= m_CrouchSpeed;  // Minkum hreyfingu með m_CrouchSpeed margfeldi þegar karakterinn er í crouch stöðu.

                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;  // Gerum collider óvirkur ef karakterinn er í crouch stöðu.
            }
            else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;  // Gerum collider virkur þegar karakterinn er ekki í crouch stöðu.

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);  // Kallar á viðburðinn OnCrouchEvent með gildinu false ef karakterinn hættir að croucha.
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);  // Ákveðum markhraða karaktersins í x-ás með því að margfalda hreyfingu með 10.
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);  // Sléttum hreyfinguna með SmoothDamp og stillum hraða á karakternum.

            if (move > 0 && !m_FacingRight)  // Ef hreyfingin er til hægri og karakternum er verið að horfa til vinstri...
            {
                Flip();  // Snúum karakternum.
            }
            else if (move < 0 && m_FacingRight)  // Ef hreyfingin er til vinstri og karakternum er verið að horfa til hægri...
            {
                Flip();  // Snúum karakternum.
            }
        }

        if (m_Grounded && jump)  // Ef karakterinn er á jörðinni og það er ýtt á hopp takkann...
        {
            m_Grounded = false;  // Karakterinn er ekki á jörðinni lengur.
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));  // Bætum þyngdarkrafti við karaktermassa til að fá hann til að hoppa.
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;  // Breytum áttinni sem karaktern er að horfa á.

        Vector3 theScale = transform.localScale;  // Sækjum stærð karaktersins í heild.
        theScale.x *= -1;  // Endurraðum stærðinni á x-ás með því að margfalda hana með -1.
        transform.localScale = theScale;  // Uppfærum stærð karaktersins.
    }
}


