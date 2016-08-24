﻿using UnityEngine;
using System.Collections;

namespace CreativeSpore.RpgMapEditor
{
	public class FollowObjectBehaviour : MonoBehaviour {

		public float DampTime = 0.15f;
		public Transform Target;

		private Vector3 velocity = Vector3.zero;
        private Camera m_camera;

        private bool m_bNotSmooth = false;
        public bool NotSmooth
        {
            set { m_bNotSmooth = value; }
        }

        void Start()
        {
            m_camera = GetComponent<Camera>();
        }
		
		// Update is called once per frame
		void Update () 
		{
			if (Target)
			{
                if (!m_bNotSmooth)
                {
                    Vector3 point = m_camera.WorldToViewportPoint(Target.position);
                    Vector3 delta = Target.position - m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                    Vector3 destination = transform.position + delta;
                    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, DampTime);
                }
                else
                {
                    Vector3 point = m_camera.WorldToViewportPoint(Target.position);
                    Vector3 delta = Target.position - m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                    Vector3 destination = transform.position + delta;
                    transform.position = destination;
                    m_bNotSmooth = false;
                }
			}		
		}
	}
}
