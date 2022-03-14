import {
    DELETE_INGREDIENTLISTITEM,
    EDIT_INGREDIENTLISTITEM,
    FETCH_INGREDIENTLISTITEMS_BY_RECIPE,
    GET_SELECTED_INGREDIENTLISTITEM,
    SET_SELECTED_INGREDIENTLISTITEM,
    NEW_INGREDIENTLISTITEM,
    NEW_INGREDIENTLISTITEMS,
} from './ingredientListItemTypes';
import { Dispatch } from 'redux';
import agent from '../../../app/api/agent';
import { IngredientListItem } from '../../../app/models/ingredientListItem';

export const fetchIngredientListItemsByRecipe = (recipeId: string | undefined) => (dispatch: Dispatch) => {
    if(recipeId){
        agent.IngredientListItems.listByRecipe(recipeId)
        .then(response => {
            dispatch({
                type: FETCH_INGREDIENTLISTITEMS_BY_RECIPE,
                payload: response
            })
        })
    }
}

export const setIngredientListItemDetails = (ingredientListItemId: string | undefined) => (dispatch: Dispatch) => {
    agent.IngredientListItems.details(ingredientListItemId ? ingredientListItemId : '').then(response => {       
        dispatch({
            type: SET_SELECTED_INGREDIENTLISTITEM,
            payload: response
        })
    })
}

export const getIngredientListItemDetails = (ingredientListItemId: string) => (dispatch: Dispatch) => {
    agent.IngredientListItems.details(ingredientListItemId).then(response => {
        dispatch({
            type: GET_SELECTED_INGREDIENTLISTITEM,
            payload: response
        })
    })
}

export const createIngredientListItem = (ingredientListItemData: IngredientListItem) => (dispatch: Dispatch) => {
    if(!ingredientListItemData) return;

    agent.IngredientListItems.create(ingredientListItemData).then(response => {
        dispatch({
            type: NEW_INGREDIENTLISTITEM,
            payload: response
        })
    })
}


export const createIngredientListItems = (ingredientListItemData: IngredientListItem[]) => (dispatch: Dispatch) => {
    if(!ingredientListItemData || ingredientListItemData.length === 0) return;

    agent.IngredientListItems.createBulk(ingredientListItemData).then(response => {
        dispatch({
            type: NEW_INGREDIENTLISTITEMS,
            payload: response
        })
    })
}

export const editIngredientListItem = (ingredientListItemData: IngredientListItem) => (dispatch: Dispatch) => {
    if(!ingredientListItemData) return;

    agent.IngredientListItems.update(ingredientListItemData).then(response => {
        dispatch({
            type: EDIT_INGREDIENTLISTITEM,
            payload: response
        })
    })
}

export const deleteIngredientListItem = (ingredientListItemId: string) => (dispatch: Dispatch) => {
    agent.IngredientListItems.delete(ingredientListItemId).then(response => {
        dispatch({
            type: DELETE_INGREDIENTLISTITEM,
            payload: response
        })
    })
}