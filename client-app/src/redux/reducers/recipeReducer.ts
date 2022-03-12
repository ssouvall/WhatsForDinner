import {
    DELETE_RECIPE,
    EDIT_RECIPE,
    FETCH_RECIPES,
    GET_SELECTED_RECIPE,
    NEW_RECIPE,
    SET_SELECTED_RECIPE,
    SET_FORM_OPEN_STATE,
    ADD_INGREDIENT_TO_RECIPE
} from '../actions/recipe/recipeTypes';
import { Recipe } from '../../app/models/recipe'

interface recipeAction {
    type: string;
    payload?: any;
    recipeToOpen?: Recipe | undefined;
    editMode?: boolean;
}

interface RecipeState {
    recipes: Recipe[];
    recipe: Recipe | undefined;
    editMode: boolean;
}

const initialState: RecipeState = {
    recipes: [],
    recipe: {
        id: '',
        name: '',
        category: '',
        description: '',
        instructions: '',
        ingredientListItems: []
    },
    editMode: false
}

export default function reducer(state = initialState, action: recipeAction ): RecipeState {
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
        case SET_FORM_OPEN_STATE:
            return {
                ...state,
                recipe: action.recipeToOpen ? action.recipeToOpen : undefined,
                editMode: action.editMode ? action.editMode : false
            }
        default:
            return state;
    }
}