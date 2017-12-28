import c = require("./Characteristic");
import Characteristic = c.Characteristic;

export class CharacteristicOption {
    public CharacteristicOptionId: string;
    public CharacteristicId: string;
    public Name: string;
    public Value: string;
    public Characteristic: Characteristic;
}