/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class LaserConsumable : Consumable
    {

        private new string NAME = "LaserConsumable";
        public LaserConsumable()

            //Codi copiat 
        public ParticleSystem laserStartParticles;
        public ParticleSystem laserEndParticiples;
        public float lineLength = 10f;
        public LineRenderer;
            private bool sfxIsPlaying = false;
        private bool startParticlesPlaying = false;
        private bool endParticlesPlaying = false;
        private RaycastHit2D hit;

        //Codi copiat Start is called before the first frame update

        void Start()
        {
            LineRenderer = GetComponent<LineRenderer>();
            AudioSource = GetComponent<AudioSource>();
        }

        //Codi copiat Update is called once per frame

        void Update ()
        {
            if (Input.GetButton("Fire1"))
            {
                if(startParticlesPlaying == false)
                {
                    startParticlesPlaying = true;
                    laserStartParticles.Play(true);
                }
                laserStartParticles.gameObject.transform.position = transform.position;
                line.enabled = true;
                if(sfxIsPlaying == false)
                {
                    sfxIsPlaying = true;
                    audioSource.Play();
                }
                hit = Physics2D.Raycast(transform.position, Vector2.right, lineLength, layerMask);
                if (hit)
                {
                    if(endParticlesPlaying == false)
                    {
                        endParticlesPlaying = true;
                        laserEndParticiples.Play(true);
                    }
                    float distance = ((Vector2)hit.point)
                }

            }
        }


        

        {
            Debug.Log("Item Created");
        }
        override public string GetName()
        {
            return this.NAME;
        }
        override public void Consume(Player target)
        {
            RaycastHit hit;

            if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 100.0f))
                print("Found an object - distance: " + hit.distance);
        }
    }
}
*/