﻿//Interface for all damagable objects
public interface IDamagable<DamageObject> {
	
	void Hit(DamageObject DO);
	void Capture(DamageObject DO);

 }

