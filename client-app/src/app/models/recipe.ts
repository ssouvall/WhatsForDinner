import { Ingredient } from "./ingredient";

export interface Recipe {
    id: string;
    name: string;
    category: string;
    description: string;
    instructions: string;
    ingredients?: Ingredient[]
}