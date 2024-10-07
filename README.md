# **Tarea de Inventario y Minions**

**Descripción**

Este proyecto es una implementación en C# de un sistema de inventario y generación de minions para un juego, donde cada personaje puede tener diferentes objetos (como armas, armaduras, y anillos)
Euiparse con anillos que invocan minions para ayudar en combate.
Eliminar minions.
La clase Character tiene la capacidad de gestionar su inventario, minions, y manejar su ataque y defensa. Los minions invocados aumentan el daño base del personaje.

## El sistema incluye las siguientes clases e interfaces principales:

**[Character](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/Character.cs#L3)**: Representa a un personaje en el juego, que tiene vida, daño base, armadura base y un inventario de objetos y minions. Los minions se agregan y eliminan con los objetos específicos.

**[Minion](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/Minion.cs#L3)**: Un ayudante que aumenta el daño del personaje mientras está activo. Los minions son invocados por objetos.

**[IItem](https://github.com/agadrian/primeraPrueba_C-/blob/0108f995a09afb6ce9ff2213f7b29a9478000969/TareaInventario/IItem.cs#L3)**: Una interfaz implementada por los objetos del inventario, que asegura que cada objeto pueda aplicar sus efectos al personaje.

**[RingMinionGenerator](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/RingMinionGenerator.cs#L3)**: Un objeto que, al ser agregado al inventario, invoca un minion.

**[Weapon](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/Weapon.cs#L4), [Protection](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/Protection.cs#L4)**: Clases abstractas que representan los tipos de objetos que puede equipar el personaje, como armas y armaduras.


### Diagrama de clases: 
Este es el [diagrama de clases](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/Diagrama%20UML.drawio.png) simplificado que describe las relaciones entre las principales clases.



**Pruebas**
Se han realizado pruebas manueales en el [Program.cs](https://github.com/agadrian/primeraPrueba_C-/blob/331f5c1709db3a8f1e6436611220e5219d551851/TareaInventario/Program.cs#L4)  para validar y comprobar que las funcione todo debidamente. 



