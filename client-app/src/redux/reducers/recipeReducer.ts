import {
    DELETE_RECIPE,
    EDIT_RECIPE,
    FETCH_RECIPES,
    GET_SELECTED_RECIPE,
    NEW_RECIPE,
    SET_SELECTED_RECIPE
} from '../actions/recipe/recipeTypes';
import { Recipe } from '../../app/models/recipe'

interface recipeAction {
    type: string;
    payload: any;
}

interface recipeState {
    recipes: Recipe[];
    recipe: Recipe;
}

const initialState: recipeState = {
    recipes: [],
    recipe: {
        id: 0,
        name: '',
        category: '',
        description: '',
        instructions: ''
    }
}

export default function reducer(state = initialState, action: recipeAction) {
    switch (action.type) {
        case FETCH_RECIPES:
            return {
                ...state,
                recipes: action.payload
            }
        case SET_SELECTED_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        case GET_SELECTED_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        case NEW_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        case EDIT_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        case DELETE_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        default:
            return state;
    }
}