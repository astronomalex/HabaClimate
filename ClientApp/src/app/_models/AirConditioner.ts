import {Good} from "./Good";

export interface AirConditioner extends Good {
  isInverter: boolean;
  energyEffiencyClass: string;
  squareRoom: number;
}
