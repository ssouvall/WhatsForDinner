import {
    DELETE_INGREDIENT,
    EDIT_INGREDIENT,
    FETCH_INGREDIENTS,
    GET_SELECTED_INGREDIENT,
    SET_SELECTED_INGREDIENT,
    NEW_INGREDIENT
} from '../actions/ingredient/ingredientTypes';
import { Ingredient } from '../../app/models/ingredient'

interface ingredientAction {
    type: string;
    payload?: any;
    ingredientToOpen?: Ingredient | undefined;
    editMode?: boolean;
}

interface IngredientState {
    ingredients: Ingredient[];
    ingredient: Ingredient | undefined;
    editMode: boolean;
}

const initialState: IngredientState = {
    ingredients: [],
    ingredient: {
        id: '',
        name: '',
        category: 0
    },
    editMode: false
}

export default function reducer(state = initialState, action: ingredientAction ): IngredientState {
    switch (action.type) {
        case FETCH_INGREDIENTS:
            return {
                ...state,
                ingredients: action.payload
            }
        case SET_SELECTED_INGREDIENT:
            return {
                ...state,
                ingredient: action.payload
            }
        case GET_SELECTED_INGREDIENT:
            return {
                ...state,
                ingredient: action.payload
            }
        case NEW_INGREDIENT:
            return {
                ...state,
                ingredient: action.payload
            }
        case EDIT_INGREDIENT:
            return {
                ...state,
                ingredient: action.payload
            }
        case DELETE_INGREDIENT:
            return {
                ...state,
                ingredient: action.payload
            }
        default:
            return state;
    }
}