import {
    DELETE_INGREDIENT,
    EDIT_INGREDIENT,
    FETCH_INGREDIENTS,
    GET_SELECTED_INGREDIENT,
    SET_SELECTED_INGREDIENT,
    NEW_INGREDIENT
} from './ingredientTypes';
import { Dispatch } from 'redux';
import agent from '../../../app/api/agent';
import { Ingredient } from '../../../app/models/ingredient';

export const fetchIngredients = () => (dispatch: Dispatch) => {
    agent.Ingredients.list()
    .then(response => {
        dispatch({
            type: FETCH_INGREDIENTS,
            payload: response
        })
    })
}

export const setIngredientDetails = (ingredientId: string | undefined) => (dispatch: Dispatch) => {
    agent.Ingredients.details(ingredientId ? ingredientId : '').then(response => {       
        dispatch({
            type: SET_SELECTED_INGREDIENT,
            payload: response
        })
    })
}

export const getIngredientDetails = (ingredientId: string) => (dispatch: Dispatch) => {
    agent.Ingredients.details(ingredientId).then(response => {
        dispatch({
            type: GET_SELECTED_INGREDIENT,
            payload: response
        })
    })
}

export const createIngredient = (ingredientData: Ingredient) => (dispatch: Dispatch) => {
    if(!ingredientData) return;

    agent.Ingredients.create(ingredientData).then(response => {
        dispatch({
            type: NEW_INGREDIENT,
            payload: response
        })
    })
}

export const editIngredient = (ingredientData: Ingredient) => (dispatch: Dispatch) => {
    if(!ingredientData) return;

    agent.Ingredients.update(ingredientData).then(response => {
        dispatch({
            type: EDIT_INGREDIENT,
            payload: response
        })
    })
}

export const deleteIngredient = (ingredientId: string) => (dispatch: Dispatch) => {
    agent.Ingredients.delete(ingredientId).then(response => {
        dispatch({
            type: DELETE_INGREDIENT,
            payload: response
        })
    })
}