# HeroVsMonster2

UNIT TEST:

para la funcion AssignAttributeValue de PERSONALIZADO: NO hace falte UNIT TEST ya que es lo mismo que el PersonalizeAttribute pero 3 veces para cada atributo.


## USEFULL FUNCTION


### CheckRangeLimit:
- Comprueba si un valor esta dentro de los rangos que nosotros le indiquemos.

| DOMINI        | CLASSE           | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------|----------|-----------|---------------------|----------------------|
|nombres enteros| (-infinito, min] | invalid  |   FALSE   | -infinito           | min - 1              |
|nombres enteros| [min, max]       | valid    |   TRUE    |num "min" del usaurio|num "max" del usaurio |
|nombres enteros| [max, +infinito) | invalid  |   FALSE   |max + 1              |  +infinito           |


### AssignValueInRange:
- Pide al usuario introducir un valor y comprueba que esta dentro del rango, si son valores fuera de rango entonces los errores se van acumulando. En caso de fallar 3 veces, devolvera -1 indicando que el usuario se quedo sin intentos, ya que en caso de que introdujera un valor correcto, devolveria ese valor.

| DOMINI        | CLASSE                            | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-----------------------------------|----------|-----------|---------------------|----------------------|
|nombres enteros| (-infinito, +infinito), intento<3 | valid    |   - 1     | -infinito           | +infinito            |
|nombres enteros| (-infinito, +infinito), intento>3 | valid    |   - 1     | -infinito           | +infinito            |
|nombres enteros| [min, max], intento<3             | valid    |   INPUT   |  min                |  max                 |
|nombres enteros| [min, max], intento>3             | valid    |   - 1     |  min                |  max                 |


### EnterCharacterNames:
- Pide al usuario introducir una string de cuatro nombres separado con ','. La condicion se especifica dentro del procedimiento.

| DOMINI        | CLASSE                       | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------------------|----------|-----------|---------------------|----------------------|
|string (texto) | nombre, nombre, nombre...    | valid    | STRING    | 0 caracteres        | +infinito caracteres |
|string (texto) | NULL                         | invalid  | ERROR     | -                   | -                    |


### AssignNameWithString:
- Asigna los cuatro primeros nombres (separado por ',') de la cadena de nombres a cuatro diferentes variables tipo string, que seran los nombres de cada personaje.

(Es un procedimiento que pasa variables por referencia)
| DOMINI        | CLASSE                            | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-----------------------------------|----------|-----------|---------------------|----------------------|
|string (texto) | -                                 | valid    | -         | -                   | -                    |


### CopyFloatArray:
- Crea una copia de un array tipo float.

| DOMINI        | CLASSE            | TIPUS    |  RETORN       |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-------------------|----------|---------------|---------------------|----------------------|
|float (array)  | float (array)     | valid    | FLOAT (ARRAY) | -                   | -                    |
|otros (array)  | otro tipo de array| invalid  |   ERROR       | -                   | -                    |


### CopyStringArray:
- Crea una copia de un array tipo string.

| DOMINI        | CLASSE            | TIPUS    |  RETORN       |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-------------------|----------|---------------|---------------------|----------------------|
|string (array) | string (array)    | valid    | STRING (ARRAY)| -                   | -                    |
|otros (array)  | otro tipo de array| invalid  |   ERROR       | -                   | -                    |


### ExchangeFloatVariable:
- Intercambia los valores de dos variables tipo float.

(Es un procedimiento que pasa variables por referencia)
| DOMINI        | CLASSE            | TIPUS    |  RETORN       |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-------------------|----------|---------------|---------------------|----------------------|
|float          | [float, float]    | valid    | [float, float]| -                   | -                    |
|otros          | [otros, otros]    | invalid  |   ERROR       | -                   | -                    |


### ExchangeStringVariable:
- Intercambia los valores de dos variables tipo string.

(Es un procedimiento que pasa variables por referencia)
| DOMINI        | CLASSE            | TIPUS    |  RETORN         |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|-------------------|----------|-----------------|---------------------|----------------------|
|string         | [string, string]  | valid    | [string, string]| -                   | -                    |
|otros          | [otros, otros]    | invalid  |   ERROR         | -                   | -                    |


### Probability:
- Dentro de la funcion hay una variable Random que devolvera un numero aleatorio del 1 al 100, incluidos, segun el porcentage que sera introducido a traves de un parametro, la funcion devolvera TRUE en el caso de que el numero aleatorio sea inferior o igual al porcentage y en caso contrario devolvera FALSE.

| DOMINI        | CLASSE           | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------|----------|-----------|---------------------|----------------------|
|nombres enteros| (-infinito, 1)   | invalid  |   ERROR   | -infinito           | 0                    |
|nombres enteros| (100, +infinito) | invalid  |   ERROR   | 101                 |  +infinito           |
|nombres enteros| [1, 100]         | valid    |   TRUE    |1                    |100                   |
|nombres enteros| [1, 100]         | valid    |   FALSE   |1                    |100                   |


### CleanTheScreen:
- Permite limpiar la pantalla de la consola pulsando cualquier tecla.

(Es un procedimiento para ahorrar codigos en el main)
| DOMINI        | CLASSE           | TIPUS    |  RETORN   |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------|----------|-----------|---------------------|----------------------|
|-              | -                | -        |   -       | -                   | -                    |


## CREATION FUNCTION


### PersonalizeAttribute:
- Metodo para assignar un valor (introducido por el usuario) a un atributo en especifico, para el modo "personalizado". Con el sistema de errores, en caso de introducir 3 o más valores incorrectes, se le assignara al jugador el valor minimo del atributo.

| DOMINI        | CLASSE           | TIPUS    |  RETORN      |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------|----------|--------------|---------------------|----------------------|
|enteros        | (-infinito, min) | valid    |   min        | -infinito           | min                  |
|enteros        | (max, +infinito) | valid    |   min        | max                 |  +infinito           |
|enteros        | [min, max]       | valid    | min          | min                 | max                  |
|enteros        | [min, max]       | valid    | float (input)| min                 | max                  |


### AssignAttributeValue (1) (2) (3):
- (1) Asigna los valores al atributo de cada personaje, para los niveles "EASY" y "DIFFICULT".
- (2) Asigna los valores al atributo de cada personaje, para el nivel "PERSONALIZED".
- (3) Asigna los valores al atributo de cada personaje, para el nivel "RANDOM".

| DOMINI        | CLASSE           | TIPUS    |  RETORN      |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------|----------|--------------|---------------------|----------------------|
|-              | -                | -        |   -          | -                   | -                    |


### CreateFloatArray:
- Crea una array tipo float con diferentes variables del mismo tipo.

| DOMINI        | CLASSE                       | TIPUS    |  RETORN      |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------------------|----------|--------------|---------------------|----------------------|
| float         | 4 = variables por parametro  | valid    | float (array)| -infinito           | +infinito            |
| float         | 4 < variables por parametro  | invalid  | ERROR        | -infinito           | +infinito            |
| float         | 4 > variables por parametro  | invalid  | ERROR        | -infinito           | +infinito            |

### CreateStringArray:
- Crea una array tipo string con diferentes variables del mismo tipo.

| DOMINI        | CLASSE                       | TIPUS    |  RETORN       |  LIMIT INFERIOR     | LIMIT SUPERIOR       |
|---------------|------------------------------|----------|---------------|---------------------|----------------------|
| string        | 4 = variables por parametro  | valid    | string (array)| 0 caracteres        | +infinito carac.     |
| string        | 4 < variables por parametro  | invalid  | ERROR         | 0 caracteres        | +infinito carac.     |
| string        | 4 > variables por parametro  | invalid  | ERROR         | 0 caracteres        | +infinito carac.     |

## BATTLE FUNCTION


### RandomOrderBattle:
- Nos crea un array de string con los nombres de los heroes pero con un orden aleatorio, el programa ira devolviendo numeros aleatorios dentro de un rango y de esa manera se decidira el orden. Utilizaremos la funcion "CopyStringArray" para evitar que el array con el orden "aleatorio" se sincronise con el que esta "ordenado".

| DOMINI          | CLASSE                          | TIPUS    |  RETORN       | LIMIT INFERIOR  |LIMIT SUPERIOR        |
|-----------------|---------------------------------|----------|---------------|-----------------|----------------------|
| string (array)  | [nombre, nombre, nombre...]     | valid    | string (array)| 0 strings       | +infinito strings    |


### SortCharacterDescendant:
- Ordena un array tipo float de forma descendiente.

| DOMINI          | CLASSE                          | TIPUS    |  RETORN       | LIMIT INFERIOR  |LIMIT SUPERIOR        |
|-----------------|---------------------------------|----------|---------------|-----------------|----------------------|
| float (array)   | (-infinito, ..., +infinito)     | valid    | float (array) | -infinito       | +infinito            |


### SortCharacterDescendant:
- Con la ayuda del otro array tipo float ordena el array tipo string con los nombres de forma descendiente.

| DOMINI          | CLASSE                          | TIPUS    |  RETORN       | LIMIT INFERIOR  |LIMIT SUPERIOR        |
|-----------------|---------------------------------|----------|---------------|-----------------|----------------------|
| string (array)  | [nombre, nombre, nombre...]     | valid    | string (array)| 0 strings       | +infinito strings    |


### CheckIsDead:
- Valida si el personaje esta muerto o no, para hacerlo, compara el valor del parametro con '0', si es igual o inferior es que esta muerto y por lo tanto devoleria TRUE, en caso contrario, si el valor es superior a '0', entonces esta vivo, devolveria FALSE, porque no esta muerto.

| DOMINI          | CLASSE             | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|-----------------|--------------------|----------|---------------|-----------------|-----------------|
| float           | (-infinito, 0]     | valid    | TRUE          | -infinito       | 0               |
| float           | (0, +infinito]     | valid    | FALSE         | 1               | +infinito       |


### CheckDefeat:
- Valida si todos los heroes estan muertos, si es asi, gana el monstruo. Para hacerlo, compara todos los valores del array tipo float que se le pasa por parametro y utiliza la funcion "CheckIsDead" para comprobar si estan muertos o no, si solo uno de ellos sigue con vida entonces la funcion devolvera FALSE, ya que los heroes no han perdido aun, en caso de que ninguno este vivo, devolvera TRUE, que significaria su derrota.

| DOMINI          | CLASSE                  | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|-----------------|-------------------------|----------|---------------|-----------------|-----------------|
| float (array)   | (-infinito, 0] todos    | valid    | TRUE          | -infinito       | 0               |
| float (array)   | (0, +infinito] todos    | valid    | FALSE         | 1               | +infinito       |
| float (array)   | (-infinito, +infinito)  | valid    | TRUE          | -infinito       | +infinito       |
| float (array)   | (-infinito, +infinito)  | valid    | FALSE         | -infinito       | +infinito       |


### Attacked:
- Devuelve la vida que le quedaria al personaje que es atacado, despues de haber hecho los calculos con el percentage de reducion de daño. Toda la funcion se trabaja con variables tipo float, por si hay valores con decimales.

| DOMINI   | CLASSE          | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-----------------|----------|---------------|-----------------|-----------------|
| float    | (-infinito, 0)  | invalido | ERROR         | -infinito       | -1              |
| float    | (0, +infinito)  | valid    | float         | 1               | +infinito       |
| float    | [0,0]           | valid    | 0             | 0               | 0               |


### Protection:
- La funcion devuelve el doble del valor pasado por parametro. Duplica la reduccion de daño en caso de que el personaje se proteja. 

| DOMINI   | CLASSE          | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-----------------|----------|---------------|-----------------|-----------------|
| float    | (-infinito, 0)  | invalido | ERROR         | -infinito       | -1              |
| float    | (0, +infinito)  | valid    | float         | 1               | +infinito       |
| float    | [0,0]           | valid    | 0             | 0               | 0               |


### CriticalAttack:
- Duplcia el el valor del parametro pasado por parametro y escribe un aviso por pantalla. El parametro seria el daño y devolveria el doble de daño, en el caso de que sea un ataque critico.

| DOMINI   | CLASSE          | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-----------------|----------|---------------|-----------------|-----------------|
| float    | (-infinito, 0)  | invalido | ERROR         | -infinito       | -1              |
| float    | (0, +infinito)  | valid    | float         | 1               | +infinito       |
| float    | [0,0]           | valid    | 0             | 0               | 0               |


### FailedAttack:
- Devuelve '0' sin importar el valor del parametro y escribe por pantalla un aviso de que fallo el ataque.

| DOMINI   | CLASSE                  | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-------------------------|----------|---------------|-----------------|-----------------|
| float    | (-infinito, +infinito)  | valid    | 0             | -infinito       | -1              |


### HeroDamageProbabilities:
- Devuelve el valor del daño, que puede ser o critico (doble de daño), o falla (no hace daño) o un golpe normal (daño assignado). Utilizando la funcion de "probabilidad" y las dos anteriores de "critico" y "fallo". Los porcentajes estan declarados dentro de la funcion, segun la probabilidad que tenga de acertar cada una, devolvera el daño del heore, y en caso de no acertar en ninguna probabilida, devuelve el valor del daño tal y como es.

| DOMINI   | CLASSE          | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-----------------|----------|---------------|-----------------|-----------------|
| float    | (-infinito, 0)  | invalido | ERROR         | -infinito       | -1              |
| float    | [0,0]           | valid    | 0             | 0               | 0               |
| float    | (0, +infinito)  | valid    | float         | 1               | +infinito       |


### CheckCooldown:
- Valida si el la habilidad esta en enfriamiento o no. Compara dos variables tipo int, el primero como valor "inicial", el segundo como valor "final", si el "inicial" es superior o igual al "final", entonces la funcion devolvera TRUE, en caso contrario devolvera FALSE. En la partida, el valor "inicial" sera el numero de rondas actual, y el "final" sera el numero de rondas que tiene que llegar para poder volver a utilizar la habiliad.

| DOMINI   | CLASSE          | TIPUS    |  RETORN       | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|----------|-----------------|----------|---------------|-----------------|-----------------|
| entero   | [0,0]           | valid    | TRUE          | 0               | 0               |
| entero   | (-infinito, 0)  | invalido | ERROR         | -infinito       | -1              |
| entero   | (0, +infinito)  | valid    | TRUE          | 1               | +infinito       |
| entero   | (0, +infinito)  | valid    | FALSE         | 1               | +infinito       |


### MonsterAttack:
- Ataca a todos los personajes por igual, utilizando los arrays de atributos. La funcion devuelve un array tipo float con la vida de todo los personajes despues de hacer una serie de validaciones, por ejemplo, si un personaje esta muerto la funcion escribe un mensaje por pantalla y no lo ataca.

| DOMINI              | CLASSE          | TIPUS    |  RETORN         | LIMIT INFERIOR  | LIMIT SUPERIOR  |
|---------------------|-----------------|----------|-----------------|-----------------|-----------------|
| float (array) y mas | (-infinito, 0)  | invalido | ERROR           | -infinito       | -1              |
| float (array) y mas | [0, +infinito)  | valid    | float (array)   | 1               | +infinito       |


## SCREEN PRINTS PROCEDURES













