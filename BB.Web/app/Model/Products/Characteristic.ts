import co = require("./CharacteristicOption");
import CharacteristicOption = co.CharacteristicOption;

export class Characteristic {
    public CharacteristicId : string;

    public Name : string;

    public Type : number;

    public CharacteristicOptions : CharacteristicOption[];
}