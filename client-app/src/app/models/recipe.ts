import { IngredientListItem } from "./ingredientListItem";

export interface Recipe {
    id: string;
    name: string;
    category: string;
    description: string;
    instructions: string;
    ingredientListItems: IngredientListItem[]
}