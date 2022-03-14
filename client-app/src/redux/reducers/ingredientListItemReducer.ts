import {
    DELETE_INGREDIENTLISTITEM,
    EDIT_INGREDIENTLISTITEM,
    FETCH_INGREDIENTLISTITEMS_BY_RECIPE,
    GET_SELECTED_INGREDIENTLISTITEM,
    SET_SELECTED_INGREDIENTLISTITEM,
    NEW_INGREDIENTLISTITEM,
    NEW_INGREDIENTLISTITEMS
} from '../actions/ingredientListItem/ingredientListItemTypes';
import { IngredientListItem } from '../../app/models/ingredientListItem'

interface ingredientListItemAction {
    type: string;
    payload?: any;
    ingredientListItemToOpen?: IngredientListItem | undefined;
    editMode?: boolean;
}

interface IngredientListItemState {
    ingredientListItems: IngredientListItem[];
    ingredientListItem: IngredientListItem | undefined;
    editMode: boolean;
}

const initialState: IngredientListItemState = {
    ingredientListItems: [],
    ingredientListItem: {
        id: '',
        name: '',
        ingredientId: '',
        notes: '',
        quantity: 0,
        quantityUnit: '',
        recipeId: '',
        isComplete: false
    },
    editMode: false
}

export default function reducer(state = initialState, action: ingredientListItemAction ): IngredientListItemState {
    switch (action.type) {
        case FETCH_INGREDIENTLISTITEMS_BY_RECIPE:
            return {
                ...state,
                ingredientListItems: action.payload
            }
        case SET_SELECTED_INGREDIENTLISTITEM:
            return {
                ...state,
                ingredientListItem: action.payload
            }
        case GET_SELECTED_INGREDIENTLISTITEM:
            return {
                ...state,
                ingredientListItem: action.payload
            }
        case NEW_INGREDIENTLISTITEM:
            return {
                ...state,
                ingredientListItem: action.payload
            }
        case NEW_INGREDIENTLISTITEMS:
            return {
                ...state,
                ingredientListItems: action.payload
            }
        case EDIT_INGREDIENTLISTITEM:
            return {
                ...state,
                ingredientListItem: action.payload
            }
        case DELETE_INGREDIENTLISTITEM:
            return {
                ...state,
                ingredientListItem: action.payload
            }
        default:
            return state;
    }
}