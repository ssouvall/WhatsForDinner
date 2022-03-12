import { Recipe } from "./recipe";

export interface IngredientListItem {
    id: string;
    ingredientId: string;
    notes: string;
    quantity: number;
    quantityUnit: string;
    recipeId: string;
    isComplete: boolean;
}