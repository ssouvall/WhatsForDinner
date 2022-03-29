import { Recipe } from "./recipe";
import { Ingredient } from "./ingredient";

export interface ShoppingList {
    id: string;
    name: string;
    recipes: Recipe[];
    ingredients: Ingredient[];
}