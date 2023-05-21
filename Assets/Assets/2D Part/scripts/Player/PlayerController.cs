using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    private Vector3 direction;

    public Transform groundCheck;
    public Transform character;
    public LayerMask groundLayer;
    public Slider healthBar;

    public TextMeshProUGUI pointsText;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float speedVelocity = 10;
    public float jumpVelocity = 5;
    public float gravity = -15;
    public float rotationSpeed = 0.03f;

    public static int points;
    public static int currentHealth = 3;
    public static int numberOfHearts = 3;

    public static bool gameOver;

    private bool isSliding;
    public GameObject gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        gameOver = false;
    }

    private void Awake()
    {
        currentHealth = 3;
        numberOfHearts = 3;
    }

    // Update is called once per frame
    void Update()
    {
        isSliding = false;
        animator.SetBool("isSliding", isSliding);

        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        setPlayerDirection(horizontalInput * speedVelocity);


        // Check if the player is grounded
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        // Set animator values
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        animator.SetBool("isGrounded", isGrounded);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = jumpVelocity;
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            isSliding = true;
            animator.SetBool("isSliding", isSliding);
        }

        // Apply gravity
        direction.y += gravity * Time.deltaTime;

        if(horizontalInput != 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
            character.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed);
        }

        controller.Move(direction * Time.deltaTime);


        //Update number of points
        pointsText.text = "Points: " + points;

        //Set the health
        healthBar.value = currentHealth;

        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for(int i = 0; i < numberOfHearts; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        //Player Gets hit 3 times, then lose 1 heart
        if (currentHealth <= 0)
        {
            if (numberOfHearts != 0)
            {
                if (numberOfHearts == 1)
                {
                    numberOfHearts--;
                    currentHealth = 0;
                }
                else
                {
                    numberOfHearts--;
                    currentHealth = 3;
                }
            }
            else
            {
                gameOver = true;
                numberOfHearts = 0;
                currentHealth = 0;
            }
        }


        if (gameOver)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        }

    }

    public void continueGame()
    {
        Time.timeScale = 1;
        gameOverObject.SetActive(false);
        PlayerController.currentHealth = 3;
        PlayerController.numberOfHearts = 0;
    }

    public Vector3 getPlayerDirection()
    {
        return direction;
    }

    public void setPlayerDirection(float currentDirection)
    {
        direction.x = currentDirection;
    }
}
