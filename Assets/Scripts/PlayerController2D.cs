using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
	private Animator animator;

	private GameObject bulletRef;

	private Rigidbody2D rb2d;

	private SpriteRenderer spriteRenderer;

	public static bool isShooting;

	private bool isGrounded;

	[SerializeField]
	public bool facingright;

	[SerializeField]
	private Transform groundCheck;

	public AudioSource runningSound;

	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
		this.rb2d = base.GetComponent<Rigidbody2D>();
		this.spriteRenderer = base.GetComponent<SpriteRenderer>();
	}

	private void flip()
	{
		this.facingright = !this.facingright;
		base.transform.Rotate(0f, 180f, 0f);
	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Space) && this.isGrounded && !Shoot.reloading)
		{
			this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 6f);
		}
		if ((Input.GetKey("d") || Input.GetKey("right")) && !Shoot.reloading)
		{
			this.rb2d.velocity = new Vector2(3f, this.rb2d.velocity.y);
			if (this.isGrounded && !PlayerController2D.isShooting && !Shoot.reloading)
			{
				this.animator.Play("Player_Run");
			}
			if (!this.facingright)
			{
				this.flip();
			}
		}
		else if ((Input.GetKey("a") || Input.GetKey("left")) && !Shoot.reloading)
		{
			this.rb2d.velocity = new Vector2(-3f, this.rb2d.velocity.y);
			if (this.isGrounded && !PlayerController2D.isShooting && !Shoot.reloading)
			{
				this.animator.Play("Player_Run");
			}
			if (this.facingright)
			{
				this.flip();
			}
		}
		else
		{
			this.rb2d.velocity = new Vector2(0f, this.rb2d.velocity.y);
			if (!PlayerController2D.isShooting && !Shoot.reloading)
			{
				if (!UpgradeMenu.UpgradedWeapon)
				{
					this.animator.Play("Player_Idle");
				}
				else
				{
					this.animator.Play("Player_IdleUpgraded");
				}
			}
			else if (Shoot.reloading)
			{
				if (!UpgradeMenu.UpgradedWeapon)
				{
					this.animator.Play("Player_Reload");
				}
				else
				{
					this.animator.Play("Player_ReloadUpgraded");
				}
			}
			else if (!UpgradeMenu.UpgradedWeapon)
			{
				this.animator.Play("Player_Shot2");
			}
			else
			{
				this.animator.Play("Player_ShotUpgraded");
			}
		}
		if (Physics2D.Linecast(base.transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
		{
			this.isGrounded = true;
			return;
		}
		this.isGrounded = false;
	}
}
