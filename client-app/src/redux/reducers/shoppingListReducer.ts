import { Recipe } from '../../app/models/recipe';
import { ShoppingList } from '../../app/models/shoppingList';
import {
    ADD_RECIPES_TO_SHOPPINGLIST, GET_RECIPES_BY_SHOPPINGLIST, SET_SELECTED_SHOPPINGLIST
} from '../actions/shoppingList/shoppingListTypes'

interface shoppingListAction {
    type: string;
    payload: any;
}

interface ShoppingListState {
    addedRecipes: Recipe[];
    shoppingListRecipes: Recipe[];
    selectedShoppingList: ShoppingList | undefined;
}

const initialState: ShoppingListState = {
    addedRecipes: [],
    shoppingListRecipes: [],
    selectedShoppingList: undefined 
}

export default function reducer(state = initialState, action: shoppingListAction) {
    switch (action.type) {
        case ADD_RECIPES_TO_SHOPPINGLIST:
            return {
                ...state,
                addedRecipes: action.payload
            }
        case GET_RECIPES_BY_SHOPPINGLIST:
            return {
                ...state,
                shoppingListRecipes: action.payload
            }
        case SET_SELECTED_SHOPPINGLIST:
            return {
                ...state,
                selectedShoppingList: action.payload
            }
        default:
            return state;
    }
}