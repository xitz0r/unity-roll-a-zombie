using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int score = 0;
    public Text scoreText;
    private int selectedZombiePosition = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;

	// Use this for initialization
	void Start ()
    {
        this.scoreText.text = "Score: " + score;
        this.SelectZombie(this.selectedZombie);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("left"))
            this.GetZombieLeft();
        else if (Input.GetKeyDown("right"))
            this.GetZombieRight();
        else if (Input.GetKeyDown("up"))
            this.PushUp();
	}

    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;
    }

    void GetZombieLeft()
    {
        this.selectedZombiePosition--;
        if (this.selectedZombiePosition < 0)
            this.selectedZombiePosition = this.zombies.Count - 1;

        this.SelectZombie(this.zombies[this.selectedZombiePosition]);
    }

    void GetZombieRight()
    {
        this.selectedZombiePosition++;
        this.selectedZombiePosition %= this.zombies.Count;
        
        this.SelectZombie(this.zombies[this.selectedZombiePosition]);
    }

    void PushUp()
    {
        Rigidbody rb = this.selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    public void AddPoint()
    {
        this.score++;
        this.scoreText.text = "Score: " + this.score;
    }
}
