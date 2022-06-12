import { Recipe } from '../../app/models/recipe';
import {
    ADD_RECIPES_TO_SHOPPINGLIST
} from '../actions/shoppingList/shoppingListTypes'

interface shoppingListAction {
    type: string;
    payload: any;
}

interface ShoppingListState {
    addedRecipes: Recipe[];
}

const initialState: ShoppingListState = {
    addedRecipes: []
}

export default function reducer(state = initialState, action: shoppingListAction) {
    switch (action.type) {
        case ADD_RECIPES_TO_SHOPPINGLIST:
            return {
                ...state,
                addedRecipes: action.payload
            }
        default:
            return state;
    }
}