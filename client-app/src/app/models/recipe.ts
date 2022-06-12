import { IngredientListItem } from "./ingredientListItem";

export interface Recipe {
    recipeId: string;
    name: string;
    category: string;
    description: string;
    instructions: string;
    ingredientListItems: IngredientListItem[]
}