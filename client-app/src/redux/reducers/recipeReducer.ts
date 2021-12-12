import {
    FETCH_RECIPES,
    NEW_RECIPE
} from '../actions/types';
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
        case NEW_RECIPE:
            return {
                ...state,
                recipe: action.payload
            }
        default:
            return state;
    }
}