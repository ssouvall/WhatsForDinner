import axios, { AxiosResponse } from "axios";
import { Ingredient } from "../models/ingredient";
import { IngredientListItem } from "../models/ingredientListItem";
import { Recipe } from "../models/recipe";

//add delay on loading
const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'http://localhost:8000/api';

axios.interceptors.response.use(async response => {
    try {
        await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: any) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: any) => axios.put<T>(url, body).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Recipes = {
    list: () => requests.get<Recipe[]>('/recipes'),
    details: (id: string) => requests.get<Recipe>(`/recipes/${id}`),
    create: (recipe: Recipe) => requests.post<void>('/recipes', recipe),
    update: (recipe: Recipe) => requests.put<void>(`/recipes/${recipe.id}`, recipe),
    delete: (id: string) => requests.del<void>(`/recipes/${id}`),
    addIngredient: (recipe: Recipe, ingredient: Ingredient) => requests.post<void>(`/recipes/${recipe.id}/${ingredient.id}`, recipe)
}

const Ingredients = {
    list: () => requests.get<Ingredient[]>('/ingredients'),
    details: (id: string) => requests.get<Ingredient>(`/ingredients/${id}`),
    create: (ingredient: Ingredient) => requests.post<void>('/ingredients', ingredient),
    update: (ingredient: Ingredient) => requests.put<void>(`/ingredients/${ingredient.id}`, ingredient),
    delete: (id: string) => requests.del<void>(`/ingredients/${id}`),
}

const IngredientListItems = {
    listByRecipe: (recipeId: string) => requests.get<IngredientListItem[]>(`/ingredientListItems/GetIngredientListItemsByRecipe/${recipeId}`),
    details: (id: string) => requests.get<IngredientListItem>(`/ingredientListItems/${id}`),
    create: (ingredientListItem: IngredientListItem) => requests.post<void>('/ingredientListItems', ingredientListItem),
    createBulk: (ingredientListItems: IngredientListItem[]) => requests.post<void>('/ingredientListItems/CreateIngredientListItemBulk', ingredientListItems),
    update: (ingredientListItem: IngredientListItem) => requests.put<void>(`/ingredientListItems/${ingredientListItem.id}`, ingredientListItem),
    delete: (id: string) => requests.del<void>(`/ingredientListItems/${id}`),
}

const agent = {
    Recipes,
    Ingredients,
    IngredientListItems
}

export default agent;