import { Recipe } from "./recipe";
import { Ingredient } from "./ingredient";

export interface ShoppingList {
    shoppingListId: string;
    name: string;
    recipes: Recipe[];
    ingredients: Ingredient[];
}