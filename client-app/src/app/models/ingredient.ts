import { Recipe } from "./recipe";

export interface Ingredient {
    id: string;
    name: string;
    category: number;
    recipes?: Recipe[];
}