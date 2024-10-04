package Forms;

import static Forms.Direction.*;

public class Diamond extends Form {
    public Diamond(int dimension) {
        super(dimension);

    }

    public Diamond(Form toCopy) {
        super(toCopy);
    }

    protected

    @Override
    protected void erzeugeForm() {
        Form rightUpper = new Dreieck(hoehe);
        Form rightLower = new Dreieck(hoehe).drehen();
        Form leftLower  = new Dreieck(hoehe).drehen().drehen();
        Form leftUpper  = new Dreieck(hoehe).drehen().drehen().drehen();

        Form left = rightUpper.append(SOUTH, rightLower);
        Form right = leftUpper.append(SOUTH, leftLower);
        Form diamond = left.append(WEST, right);

        this.feld = diamond.feld;
    }
}
