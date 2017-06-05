using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States{cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0,
		stairs_0, stairs_1, stairs_2, courtyard, floor, corridor_1, corridor_2,corridor_3,
		closet_door, in_closet,freedom};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.cell;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();			
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		} else if (myState == States.sheets_1) {
			state_sheets_1 ();
		} else if (myState == States.lock_1) {
			state_lock_1 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror ();
		} else if (myState == States.freedom) {
			state_freedom ();
		} else if (myState == States.corridor_0) {
			state_corridor_0 ();
		} else if (myState == States.stairs_0) {
			state_stairs_0 ();
		} else if (myState == States.stairs_1) {
			state_stairs_1 ();
		} else if (myState == States.stairs_2) {
			state_stairs_2 ();
		} else if (myState == States.courtyard) {
			state_courtyard ();
		} else if (myState == States.floor) {
			state_floor ();
		} else if (myState == States.corridor_1) {
			state_corridor_1 ();
		} else if (myState == States.corridor_2) {
			state_corridor_2 ();
		} else if (myState == States.corridor_3) {
			state_corridor_3 ();
		} else if (myState == States.closet_door) {
			state_closet_door ();
		} else if (myState == States.in_closet) {
			state_in_closet ();
		}
	}

	#region métodos del control de estados
	void state_corridor_0(){
		text.text = "Estás en un corredor fuera de la celda pero aún estás en peligro"
			+ "Hay un closet, unas escaleras que llevan al patio y algo de escombro en el suelo."
			+ "\n\nPresiona [C] para ver el closet, [S] para inspeccionar el suelo y [E] para subir las escaleras.";

		if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.floor;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_door;
		}
	}

	void state_corridor_1(){
		text.text = "Todavía en el corredor, el suelo sigue sucio y tienes un clip en la mano."
			+ "¿Ahora qué? Comienzas a pensar si el candado del closet podría ceder si lo fuerzas.\n\n"
			+ " Presiona [F] para forzar o [E] para subir las escaleras.";
		if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.in_closet;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.stairs_1;
		}
	}

	void state_corridor_2(){

		text.text = "De vuelta en el corredor renunciando a vestirte como un empleado de"
			+ " limpieza.\n\nPresiona [C] para regresar al closet o [E] para subir las escaleras.";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.in_closet;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.stairs_2;
		}
	}

	void state_corridor_3(){
		text.text = "Estás de pie en el corredor vestido como un empleado de limpieza, consideras seriamente"
			+ " caminar hacia la libertad.\n\nPresiona [E] para tomar las escaleras o [D] para desvestirte.";

		if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.courtyard;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.in_closet;
		}
	}

	void state_stairs_0(){
		text.text = "Comienzas a subir las escaleras hacía la luz proveniente de afuera."
			+ " Te das cuenta que no es tiempo del descanso y que serás captura inmediatamente."
			+ " Regresas a las escaleras a pensar.\n\nPresiona [R] para regresar al corredor.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void state_stairs_1(){
		text.text = "Desafortunadamente blander el clip de papel no te ha dado la confianza para"
			+ " caminar en el patio rodeado de guardias armados.\n\nPresiona [R] para regresar a las escaleras.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_1;
		}
	}

	void state_stairs_2(){
		text.text = "Te sientes orgulloso de haber abierto la puerta del closet, aún tienes el clip"
			+ " para papel(ahora muy doblado). A pesar de estos logros todavía no te sientes listo para"
			+ " subir las escaleras y enfrentar tu muerte.\n\nPresiona [R] para regresar al corredor.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_2;
		}
	}

	void state_courtyard(){
		text.text = "Atraviesas el patio vestido de un empleado de limpieza. El guardia se lleva"
			+ " la mano a su gorro en el momento en que pasas caminando logrando tu libertad. Tu corazón late"
			+ " fuertemente mientras caminas hacia el ocaso.\n\nPresiona [N] para jugar de nuevo.";
		if (Input.GetKeyDown (KeyCode.N)) {
			myState = States.cell;
		}
	}
	void state_floor(){
		text.text = "Explorando alrededor del piso hediondo encuentras un clip para papel.\n\n"
			+ "Presiona [R] para regresar o [C] para tomar el clip.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.corridor_1;
		}
	}

	void state_closet_door(){
		text.text = "Observas la puerta de un closet, desafortunadamente está cerrada. ¿Tal vez"
		+ " podrías encontrar algo para abrirla?\n\nPresiona [R] para regresar el corredor";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void state_in_closet(){
		text.text = "Dentro del closet ves el uniforme de un empleado de limpieza que parece de"
			+ " tu tamaño. Parece que tu día está mejorando.\n\nPresiona [V] para vestirte con"
			+ " el uniforme o [R] para regresar al corredor.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.corridor_2;
		} else if (Input.GetKeyDown (KeyCode.V)) {
			myState = States.corridor_3;
		}
	}

	void state_cell(){
		text.text = "Estás dentro de una celda y quieres escapar. Hay un par de sábanas "
			+ "sucias sobre la cama, un espejo en la pared y una puerta que está "
			+ "cerrada con candado\n\nPresiona [S] para ver las sábanas, [E] para ver"
			+ " el espejo y [C] para ver el candado.";

		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown (KeyCode.E)) {
			myState = States.mirror;
		}
		else if(Input.GetKeyDown(KeyCode.C)){
			myState = States.lock_0;
		}
	}

	void state_sheets_0(){
		text.text = "No puedes creer que dormiste en esas sábanas. Seguramente "
		+ "es tiempo de que alguien las cambie. Deben sen los placeres de prisión."
		+ "\n\nPresiona [R] para regresar.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_sheets_1(){
		text.text = "Sosteniendo el espejo entre tus manos no hace que las "
			+ "sábanas se vean mejor.\n\nPresiona [R] para regresar.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
			
	}

	void state_lock_0(){
		text.text = "Este es un candado de botones, no tienes idea acerca de la "
			+ "combinación. Desearías que de alguna manera pudieras ver los botones "
			+ "más gastados.\n\nPresiona [R] para regresar.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_1(){
		text.text = "Colocas cuidadosamente el espejo a través de las barras "
			+ "y lo colocas de tal manera que puedes ver el candado. Observas las huellas"
			+ " alrededor de los botones, los presionas y escuchas un ¡Click!"
			+ "\n\nPresiona [A] para abrir la puerta o [R] para regresar a la celda.";

		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.corridor_0;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_mirror(){
		text.text = "El espejo sucio en la pared parece que está algo suelto."
			+ "\n\nPresiona [T] para tomarlo o [R] para regresar.";

		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_cell_mirror(){
		text.text = "Sigues en la celda, y aún quieres escapar. Hay"
			+ " unas sábanas sucias sobre la cama y una marca donde"
			+ " estaba el espejo, y la condenada puerta sigue igual de imponente."
			+ "\n\nPresiona [S] para ver las sábanas o [C] para ver el candado.";

		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.lock_1;
		}
	}

	void state_freedom(){
		text.text = "Abres la puerta del patio y te das cuenta que...\n¡Finalmente eres LIBRE!\n\nPresiona [J] para jugar de nuevo.";
		if (Input.GetKeyDown (KeyCode.J)) {
			myState = States.cell;
		}
	}

	#endregion
}
