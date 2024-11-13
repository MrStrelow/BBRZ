package lerneinheiten.L04InterfacesUndAbstrakteKlassen.forms;

import static lerneinheiten.L04InterfacesUndAbstrakteKlassen.forms.Direction.*;

public class Diamond extends Form {
    public Diamond(int dimension) {
        super(dimension);

    }

    public Diamond(Form toCopy) {
        super(toCopy);
    }

    @Override
    protected void erzeugeForm() {
        Form rightUpper = new Dreieck(hoehe);
        Form rightLower = new Dreieck(hoehe).drehen();
        Form leftLower  = new Dreieck(hoehe).drehen().drehen();
        Form leftUpper  = new Dreieck(hoehe).drehen().drehen().drehen();

        Form left = rightUpper.append(rightLower, SOUTH);
        Form right = leftUpper.append(leftLower, SOUTH);
        Form diamond = left.append(right, WEST);

        this.feld = diamond.feld;
    }
}
