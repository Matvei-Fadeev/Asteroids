using Core.Managers.Score;
using UnityEngine;

namespace Core.Weapon.Type {
	public class ScoreBullet : Bullet {
		protected override void OnCollisionEnter2D(Collision2D collision) {
			base.OnCollisionEnter2D(collision);

			var scorePoints = collision.gameObject.GetComponent<ScorePoints>();
			if (scorePoints) {
				scorePoints.SendScore();
			}
		}
	}
}